using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.Models.Models.BrandModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.BrandManager;

public class BrandManager : IBrandManager
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter, string[]? includes)
    {
        return await _brandRepository.GetAll(filter, includes);
    }

    public async Task<Brand> Get(Expression<Func<Brand, bool>> filter, string[]? includes)
    {
        return await _brandRepository.Get(filter, includes);
    }

    public async Task<bool> Create(Brand entity)
    {
        if (await _brandRepository.Create(entity) is not null)
            return true;
        else
            return false;
    }

    public async Task<Brand> Update(Brand entity)
    {
        var updated = _brandRepository.Update(entity);
        await Save();
        return updated;
    }

    public async Task<bool> UpdateRange(Expression<Func<Brand, bool>> filter)
    {
        return await _brandRepository.UpdateRange(filter);
    }

    public async Task<bool> Delete(Brand entity)
    {
        return await _brandRepository.Delete(entity);
    }

    public async Task<bool> DeleteRange(Expression<Func<Brand, bool>> filter)
    {
        return await _brandRepository.DeleteRange(filter);
    }

    public async Task<int> Save()
    {
        return await _brandRepository.Save();
    }
}
