using System.Linq.Expressions;
using SavanNah.DataAccess.Repositories.Categories;

namespace SavanNah.Business.Managers.Category;

public class CategoryManager : ICategoryManager

{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Models.Models.Category>> GetAll(Expression<Func<Models.Models.Category, bool>>? filter)
    {
        return await _categoryRepository.GetAll(filter);
    }

    public async Task<Models.Models.Category> Get(Expression<Func<Models.Models.Category, bool>> filter)
    {
        return await _categoryRepository.Get(filter);
    }

    public async Task<bool> Create(Models.Models.Category entity)
    {
        return await _categoryRepository.Create(entity);
    }

    public async Task<bool> Update(Models.Models.Category entity)
    {
        return await _categoryRepository.Update(entity);
    }

    public async Task<bool> UpdateRange(Expression<Func<Models.Models.Category, bool>> filter)
    {
        return await _categoryRepository.UpdateRange(filter);
    }

    public async Task<bool> Delete(Models.Models.Category entity)
    {
        return await _categoryRepository.Delete(entity);
    }

    public async Task<bool> DeleteRange(Expression<Func<Models.Models.Category, bool>> filter)
    {
        return await _categoryRepository.DeleteRange(filter);
    }

    public async Task<int> Save()
    {
        return await _categoryRepository.Save();
    }
}
