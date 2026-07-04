using System.Linq.Expressions;

namespace SavanNah.Business.Managers.Brand;

public interface IBrandManager
{
    Task<IEnumerable<Models.Models.Brand>> GetAll(Expression<Func<Models.Models.Brand, bool>>? filter);
    Task<Models.Models.Brand> Get(Expression<Func<Models.Models.Brand, bool>> filter);
    Task<bool> Create(Models.Models.Brand entity);
    Task<bool> Update(Models.Models.Brand entity);
    Task<bool> UpdateRange(Expression<Func<Models.Models.Brand, bool>> filter);
    Task<bool> Delete(Models.Models.Brand entity);
    Task<bool> DeleteRange(Expression<Func<Models.Models.Brand, bool>> filter);
    Task<int> Save();
}
