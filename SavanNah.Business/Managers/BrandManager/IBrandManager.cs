using System.Linq.Expressions;
using SavanNah.Models.Models.BrandModel;

namespace SavanNah.Business.Managers.BrandManager;

public interface IBrandManager
{
    Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter);
    Task<Brand> Get(Expression<Func<Brand, bool>> filter);
    Task<bool> Create(Brand entity);
    Task<bool> Update(Brand entity);
    Task<bool> UpdateRange(Expression<Func<Brand, bool>> filter);
    Task<bool> Delete(Brand entity);
    Task<bool> DeleteRange(Expression<Func<Brand, bool>> filter);
    Task<int> Save();
}
