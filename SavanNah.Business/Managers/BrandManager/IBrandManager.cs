using SavanNah.Models.Models.BrandModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.BrandManager;

public interface IBrandManager
{
    Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter, string[]? includes);
    Task<Brand> Get(Expression<Func<Brand, bool>> filter, string[]? includes);
    Task<bool> Create(Brand entity);
    Task<Brand> Update(Brand entity);
    Task<bool> UpdateRange(Expression<Func<Brand, bool>> filter);
    Task<bool> Delete(Brand entity);
    Task<bool> DeleteRange(Expression<Func<Brand, bool>> filter);
    Task<int> Save();
}
