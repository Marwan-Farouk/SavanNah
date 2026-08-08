using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.DataAccess.Repositories.CategoryProducts;
using SavanNah.DataAccess.Repositories.Products;
using SavanNah.Models.DTOs.Products;
using SavanNah.Models.Models.CategoryModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.CategoryManager;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryProductRepository _categoryProductRepository;

    public CategoryManager(ICategoryRepository categoryRepository, IProductRepository productRepository, ICategoryProductRepository categoryProductRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        this._categoryProductRepository = categoryProductRepository;
    }

    public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>>? filter, string[]? includes)
    {
        return await _categoryRepository.GetAll(filter, includes);
    }

    public async Task<Category> Get(Expression<Func<Category, bool>> filter, string[]? includes)
    {
        return await _categoryRepository.Get(filter, includes);
    }

    public async Task<bool> Create(Category entity)
    {
        if (await _categoryRepository.Create(entity) is not null)
            return true;
        else
            return false;
    }

    public async Task<Category> Update(Category entity)
    {
        var updated = _categoryRepository.Update(entity);
        await Save();
        return updated;
    }

    public async Task<bool> UpdateRange(Expression<Func<Category, bool>> filter)
    {
        return await _categoryRepository.UpdateRange(filter);
    }

    public async Task<bool> Delete(Category entity)
    {
        return await _categoryRepository.Delete(entity);
    }

    public async Task<bool> DeleteRange(Expression<Func<Category, bool>> filter)
    {
        return await _categoryRepository.DeleteRange(filter);
    }
    public async Task<IEnumerable<ProductDTO>> GetCategoryProducts(int categoryId)
    {
        var categoryProducts = await _categoryProductRepository.GetAll(cp => cp.CategoryId == categoryId, ["Category", "Products"]);
        var products = categoryProducts.Select(cp => ProductDtoExtensions.EntityToDto(cp.Products));
        return products;
    }
    public async Task<int> Save()
    {
        return await _categoryRepository.Save();
    }
}
