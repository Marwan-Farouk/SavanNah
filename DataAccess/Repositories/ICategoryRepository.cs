using System;
using DataAccess.Entities;

namespace DataAccess.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    public void Update(Category category);
    public Task Save();
}
