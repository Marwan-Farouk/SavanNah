using SavanNah.Models.Models.CategoryModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.CategoryManager;

public interface ICategoryManager
{
    Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>>? filter, string[]? includes);
    Task<Category> Get(Expression<Func<Category, bool>> filter, string[]? includes);
    Task<bool> Create(Category entity);
    Task<Category> Update(Category entity);
    Task<bool> UpdateRange(Expression<Func<Category, bool>> filter);
    Task<bool> Delete(Category entity);
    Task<bool> DeleteRange(Expression<Func<Category, bool>> filter);
    Task<int> Save();
}
