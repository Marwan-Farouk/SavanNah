using System;
using System.Linq.Expressions;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDBContext _context;

    public CategoryRepository(ApplicationDBContext context) : base(context)
    {
        _context = context;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Category category)
    {
        _context.Update(category);
    }

}
