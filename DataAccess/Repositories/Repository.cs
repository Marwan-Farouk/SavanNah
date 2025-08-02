using System;
using System.Linq.Expressions;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDBContext _context;
    internal DbSet<T> _set;
    public Repository(ApplicationDBContext dBContext)
    {
        _context = dBContext;
        _set = _context.Set<T>(); //& ==> _context.Categories = _set
    }
    public async Task Create(T entity)
    {
        await _set.AddAsync(entity);
    }
    public async Task<T?> Get(Expression<Func<T, bool>> filter)
    {
        return await _set.Where(filter).FirstAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _set.ToListAsync();
    }

    public void Delete(T entity)
    {
        _set.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entityList)
    {
        _set.RemoveRange(entityList);
    }

}
