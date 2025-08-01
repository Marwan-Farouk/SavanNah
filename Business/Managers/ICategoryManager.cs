using System;
using Business.DTOs;

namespace Business.Managers;

public interface ICategoryManager
{
    public Task<List<AllCategoriesDTO>> GetAllCategories();
    public Task<CategoryDTO?> GetCategoryById(int id);
    public Task CreateCategory(CategoryDTO dto);
    public Task UpdateCategory(CategoryDTO dto);
    public Task DeleteCategory(CategoryDTO dto);
}
