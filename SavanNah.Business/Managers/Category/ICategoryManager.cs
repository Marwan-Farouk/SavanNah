using System.Linq.Expressions;

namespace SavanNah.Business.Managers.Category;

public interface ICategoryManager
{
    Task<IEnumerable<Models.Models.Category>> GetAll(Expression<Func<Models.Models.Category, bool>>? filter);
    Task<Models.Models.Category> Get(Expression<Func<Models.Models.Category, bool>> filter);
    Task<bool> Create(Models.Models.Category entity);
    Task<bool> Update(Models.Models.Category entity);
    Task<bool> UpdateRange(Expression<Func<Models.Models.Category, bool>> filter);
    Task<bool> Delete(Models.Models.Category entity);
    Task<bool> DeleteRange(Expression<Func<Models.Models.Category, bool>> filter);
    Task<int> Save();
}
