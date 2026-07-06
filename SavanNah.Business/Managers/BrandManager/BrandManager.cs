using System.Linq.Expressions;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.Models.Models.BrandModel;

namespace SavanNah.Business.Managers.BrandManager;

public class BrandManager : IBrandManager
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<Brand>> GetAll(Expression<Func<Brand, bool>>? filter)
    {
        return await _brandRepository.GetAll(filter);
    }

    public async Task<Brand> Get(Expression<Func<Brand, bool>> filter)
    {
        return await _brandRepository.Get(filter);
    }

    public async Task<bool> Create(Brand entity)
    {
        if (await _brandRepository.Create(entity) is not null)
            return true;
        else
            return false;
    }

    public async Task<bool> Update(Brand entity)
    {
        return await _brandRepository.Update(entity);
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
