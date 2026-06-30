using Microsoft.EntityFrameworkCore;
using SavanNah.DataAccess.Contexts;
using System.Linq.Expressions;

namespace SavanNah.DataAccess.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public async Task<bool> Create(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
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
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await dbSet.Where(filter).ToListAsync();
            try
            {
                dbSet.RemoveRange(filteredEntities);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await dbSet.FirstAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter)
        {
            if (filter is null)
                return await dbSet.ToListAsync();
            else
                return await dbSet.Where(filter).ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRange(Expression<Func<T, bool>> filter)
        {
            var filteredEntities = await dbSet.Where(filter).ToListAsync();
            try
            {
                dbSet.UpdateRange(filteredEntities);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
