using System;
using Business.DTOs;
using DataAccess.Repositories;

namespace Business.Managers;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

    }
    public async Task CreateCategory(CategoryDTO dto)
    {
        await _categoryRepository.Create(dto.ToEntity());
        await _categoryRepository.Save();
    }

    public async Task DeleteCategory(CategoryDTO dto)
    {
        _categoryRepository.Delete(dto.ToEntity());
        await _categoryRepository.Save();
    }

    public async Task<List<AllCategoriesDTO>> GetAllCategories()
    {
        var entitiesList = await _categoryRepository.GetAll();

        return entitiesList.Select(cat => cat.ToDTOAll()).ToList();
    }

    public async Task<CategoryDTO?> GetCategoryById(int iD)
    {
        var result = await _categoryRepository.Get(cat => cat.id == iD);
        return result!.ToDTO();
    }

    public async Task UpdateCategory(CategoryDTO dto)
    {
        _categoryRepository.Update(dto.ToEntity());
        await _categoryRepository.Save();
    }
}
