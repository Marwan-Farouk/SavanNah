using System;
using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface ICategoryRepository
{
    public Task<List<Category>> GetAllCategories();
    public Task<Category?> GetCategoryById(int id);
    public Task CreateCategory(Category category);
    public Task UpdateCategory(Category category);
    public Task DeleteCategory(Category category);

}
