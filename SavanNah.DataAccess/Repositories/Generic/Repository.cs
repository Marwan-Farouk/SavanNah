using Microsoft.EntityFrameworkCore;
using SavanNah.DataAccess.Contexts;
using System.Linq.Expressions;

namespace SavanNah.DataAccess.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<bool> Create(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> Delete(T entity)
        {
            try
            {
                try
                {
                    _dbSet.Remove(entity);
                    return Task.FromResult(true);
                }
                catch (Exception)
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception exception)
            {
                return Task.FromException<bool>(exception);
            }
        }

        public async Task<bool> DeleteRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await _dbSet.Where(filter).ToListAsync();
            try
            {
                _dbSet.RemoveRange(filteredEntities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter)
        {
            if (filter is null)
                return await _dbSet.ToListAsync();
            else
                return await _dbSet.Where(filter).ToListAsync();
        }

        public Task<bool> Update(T entity)
        {
            try
            {
                try
                {
                    _dbSet.Update(entity);
                    return Task.FromResult(true);
                }
                catch (Exception)
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception exception)
            {
                return Task.FromException<bool>(exception);
            }
        }

        public async Task<bool> UpdateRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await _dbSet.Where(filter).ToListAsync();
            try
            {
                _dbSet.UpdateRange(filteredEntities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
