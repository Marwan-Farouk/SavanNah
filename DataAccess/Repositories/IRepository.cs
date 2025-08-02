using System;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public interface IRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> Get(Expression<Func<T, bool>> filter);
    public Task Create(T entity);

    //! public Task Update(T entity); ===> Will Be Implemented in Custom Repos Instead
    //! public Task Save(T entity); ===> Will Be Implemented in Custom Repos Instead
    public void Delete(T entity);
    public void DeleteRange(IEnumerable<T> entityList);
}
