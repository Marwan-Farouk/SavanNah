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
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await _dbSet.Where(filter).ToListAsync();
            try
            {
                _dbSet.RemoveRange(filteredEntities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<bool> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await _dbSet.Where(filter).ToListAsync();
            try
            {
                _dbSet.UpdateRange(filteredEntities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
