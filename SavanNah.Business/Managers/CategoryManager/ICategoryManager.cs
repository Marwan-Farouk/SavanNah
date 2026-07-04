using System.Linq.Expressions;
using SavanNah.Models.Models.CategoryModel;

namespace SavanNah.Business.Managers.CategoryManager;

public interface ICategoryManager
{
    Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>>? filter);
    Task<Category> Get(Expression<Func<Category, bool>> filter);
    Task<bool> Create(Category entity);
    Task<bool> Update(Category entity);
    Task<bool> UpdateRange(Expression<Func<Category, bool>> filter);
    Task<bool> Delete(Category entity);
    Task<bool> DeleteRange(Expression<Func<Category, bool>> filter);
    Task<int> Save();
}
