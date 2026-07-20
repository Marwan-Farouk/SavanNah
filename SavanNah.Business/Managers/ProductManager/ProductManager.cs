using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.DataAccess.Repositories.CategoryProducts;
using SavanNah.DataAccess.Repositories.Products;
using SavanNah.Models.DTOs.Products;
using SavanNah.Models.Models.CategoryProductModel;
using SavanNah.Models.Models.ProductModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.ProductManager;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryProductRepository _categoryProductRepository;

    public ProductManager(IProductRepository productRepository, IBrandRepository brandRepository,
        ICategoryRepository categoryRepository, ICategoryProductRepository categoryProductRepository,
        AppDbContext context)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
        _categoryRepository = categoryRepository;
        _categoryProductRepository = categoryProductRepository;
    }

    public async Task<bool> Create(CreateProductDTO productDto)
    {
        var product = productDto.ToEntity();
        var created = await _productRepository.Create(product);
        await _productRepository.Save();
        if (created is not null)
        {
            foreach (var catId in productDto.CategoryIds)
            {
                await _categoryProductRepository.Create(new CategoryProduct

                {
                    CategoryId = catId,
                    ProductsId = created.Id
                });
            }

            await Save();
            return true;
        }

        return false;
    }

    public async Task<Product> Update(UpdateProductDTO productDto)
    {
        var updated = _productRepository.Update(productDto.ToEntity());
        await Save();
        if (updated is not null)
        {
            var existingCategoryProdcuts = await _categoryProductRepository.GetAll(cp => cp.ProductsId == updated.Id, []);
            var categoryProdcutsToRemove = existingCategoryProdcuts.Where(cp => !productDto.CategoryIds.Contains(cp.CategoryId)).ToList();
            foreach (var cp in categoryProdcutsToRemove)
            {
                await _categoryProductRepository.Delete(cp);
            }
            var existingCategoriesIds = existingCategoryProdcuts.Select(cp => cp.CategoryId).ToList();
            var categoriesToAdd = productDto.CategoryIds.Where(catId => !existingCategoriesIds.Contains(catId)).ToList();
            foreach (var catId in categoriesToAdd)
            {
                await _categoryProductRepository.Create(new CategoryProduct
                {
                    CategoryId = catId,
                    ProductsId = updated.Id
                });
            }

            await Save();
        }
        return updated;
    }

    public async Task<bool> Delete(Product entity)
    {
        var sucssess = await _productRepository.Delete(entity);
        if (sucssess)
        {
            await Save();
            return true;
        }
        return false;
    }

    public Task<int> Save()
    {
        return _productRepository.Save();
    }

    public async Task<Product> Get(Expression<Func<Product, bool>> filter, string[]? includes)
    {
        return await _productRepository.Get(filter, includes);
    }

    public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? filter, string[]? includes)
    {
        return await _productRepository.GetAll(filter, includes);
    }

    //public async Task<List<SelectListItem>> GetBrands() => (await _brandRepository.GetAll(b => true, []))
    //    .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();

    //public async Task<List<SelectListItem>> GetCategories() => (await _categoryRepository.GetAll(c => true, []))
    //    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

    //public async Task<List<AllProductsVM>> CreateIndexVMs()
    //{
    //    var products = await GetAll(null);
    //    var vmList = (await Task.WhenAll(products.Select(async product =>
    //    {
    //        var brand = await _brandRepository.Get(b => b.Id == product.BrandId);
    //        var brandName = brand.Name;
    //        var categoryProducts = await _categoryProductRepository.GetAll(cp => cp.ProductsId == product.Id);
    //        var categoryNames = (await Task.WhenAll(categoryProducts.Select(async cp =>
    //        {
    //            var categories = await Task.WhenAll(_categoryRepository.Get(cat => cat.Id == cp.CategoryId));
    //            return categories.Select(c => c.Name).FirstOrDefault();
    //        }))).ToList();
    //        return new AllProductsVM
    //        {
    //            Product = product,
    //            BrandName = brandName,
    //            CategoryNames = categoryNames

    //        };
    //    }).ToList()));

    //    return vmList.ToList();
    //}
}