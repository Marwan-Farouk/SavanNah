using System;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDBContext _context;

    public CategoryRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task CreateCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryById(int _id)
    {
        return await _context.Categories.FirstOrDefaultAsync(cat => cat.id == _id);
    }
    public async Task UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

    }
}
