using System.Linq.Expressions;
using SavanNah.DataAccess.Repositories.Brands;

namespace SavanNah.Business.Managers.Brand;

public class BrandManager : IBrandManager
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<Models.Models.Brand>> GetAll(Expression<Func<Models.Models.Brand, bool>>? filter)
    {
        return await _brandRepository.GetAll(filter);
    }

    public async Task<Models.Models.Brand> Get(Expression<Func<Models.Models.Brand, bool>> filter)
    {
        return await _brandRepository.Get(filter);
    }

    public async Task<bool> Create(Models.Models.Brand entity)
    {
        return await _brandRepository.Create(entity);
    }

    public async Task<bool> Update(Models.Models.Brand entity)
    {
        return await _brandRepository.Update(entity);
    }

    public async Task<bool> UpdateRange(Expression<Func<Models.Models.Brand, bool>> filter)
    {
        return await _brandRepository.UpdateRange(filter);
    }

    public async Task<bool> Delete(Models.Models.Brand entity)
    {
        return await _brandRepository.Delete(entity);
    }

    public async Task<bool> DeleteRange(Expression<Func<Models.Models.Brand, bool>> filter)
    {
        return await _brandRepository.DeleteRange(filter);
    }

    public async Task<int> Save()
    {
        return await _brandRepository.Save();
    }
}
