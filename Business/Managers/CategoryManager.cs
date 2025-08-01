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
        await _categoryRepository.CreateCategory(dto.ToEntity());
    }

    public async Task DeleteCategory(CategoryDTO dto)
    {
        await _categoryRepository.DeleteCategory(dto.ToEntity());
    }

    public async Task<List<AllCategoriesDTO>> GetAllCategories()
    {
        var entitiesList = await _categoryRepository.GetAllCategories();

        return entitiesList.Select(cat => cat.ToDTOAll()).ToList();
    }

    public async Task<CategoryDTO?> GetCategoryById(int id)
    {
        var result = await _categoryRepository.GetCategoryById(id);
        return result!.ToDTO();
    }

    public async Task UpdateCategory(CategoryDTO dto)
    {
        await _categoryRepository.UpdateCategory(dto.ToEntity());
    }
}
