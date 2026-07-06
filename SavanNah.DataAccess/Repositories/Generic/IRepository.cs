using System.Linq.Expressions;

namespace SavanNah.DataAccess.Repositories.Generic
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> UpdateRange(Expression<Func<T, bool>> filter);
        Task<bool> Delete(T entity);
        Task<bool> DeleteRange(Expression<Func<T, bool>> filter);
        Task<int> Save();
    }
}
