using System.Linq.Expressions;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.Models.Models.CategoryModel;

namespace SavanNah.Business.Managers.CategoryManager;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>>? filter)
    {
        return await _categoryRepository.GetAll(filter);
    }

    public async Task<Category> Get(Expression<Func<Category, bool>> filter)
    {
        return await _categoryRepository.Get(filter);
    }

    public async Task<bool> Create(Category entity)
    {
        if (await _categoryRepository.Create(entity) is not null)
            return true;
        else
            return false;
    }

    public async Task<bool> Update(Category entity)
    {
        return await _categoryRepository.Update(entity);
    }

    public async Task<bool> UpdateRange(Expression<Func<Category, bool>> filter)
    {
        return await _categoryRepository.UpdateRange(filter);
    }

    public async Task<bool> Delete(Category entity)
    {
        return await _categoryRepository.Delete(entity);
    }

    public async Task<bool> DeleteRange(Expression<Func<Category, bool>> filter)
    {
        return await _categoryRepository.DeleteRange(filter);
    }

    public async Task<int> Save()
    {
        return await _categoryRepository.Save();
    }
}
