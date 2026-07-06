using Microsoft.AspNetCore.Mvc.Rendering;
using SavanNah.Business.DTOs.Products;
using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.DataAccess.Repositories.CategoryProducts;
using SavanNah.DataAccess.Repositories.Products;
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

    public Task<bool> Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRange(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
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

    public Task<bool> DeleteRange(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<int> Save()
    {
        return _productRepository.Save();
    }

    public async Task<Product> Get(Expression<Func<Product, bool>> filter)
    {
        return await _productRepository.Get(filter);
    }

    public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? filter)
    {
        return await _productRepository.GetAll(filter);
    }

    public async Task<List<SelectListItem>> GetBrands() => (await _brandRepository.GetAll(null))
        .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();

    public async Task<List<SelectListItem>> GetCategories() => (await _categoryRepository.GetAll(null))
        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
}