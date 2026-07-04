using System.Linq.Expressions;
using SavanNah.Models.Models;

namespace SavanNah.Business.Managers;

public interface IProductManager
{
    Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? filter);
    Task<Product> Get(Expression<Func<Product, bool>> filter);
    Task<bool> Create(Product entity);
    Task<bool> Update(Product entity);
    Task<bool> UpdateRange(Expression<Func<Product, bool>> filter);
    Task<bool> Delete(Product entity);
    Task<bool> DeleteRange(Expression<Func<Product, bool>> filter);
    Task<int> Save();
}