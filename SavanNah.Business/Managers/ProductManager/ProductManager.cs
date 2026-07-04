using System.Linq.Expressions;
using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.DataAccess.Repositories.CategoryProducts;
using SavanNah.DataAccess.Repositories.Products;
using SavanNah.Models.Models.ProductModel;

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

    public async Task<bool> Create(Product product)
    {
        return await _productRepository.Create(product);
    }

    public Task<bool> Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRange(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Product entity)
    {
        throw new NotImplementedException();
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
}