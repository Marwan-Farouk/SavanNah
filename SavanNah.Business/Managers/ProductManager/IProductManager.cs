using SavanNah.Models.DTOs.Products;
using SavanNah.Models.Models.ProductModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.ProductManager;

public interface IProductManager
{
    Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? filter, string[]? includes);
    Task<Product> Get(Expression<Func<Product, bool>> filter, string[]? includes);
    Task<bool> Create(CreateProductDTO entity);
    Task<Product> Update(UpdateProductDTO entity);
    Task<bool> Delete(Product entity);
    Task<int> Save();
    //Task<List<SelectListItem>> GetCategories();
    //Task<List<SelectListItem>> GetBrands();
    //public Task<List<AllProductsVM>> CreateIndexVMs();

}