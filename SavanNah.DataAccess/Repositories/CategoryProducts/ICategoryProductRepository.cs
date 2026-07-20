using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.CategoryProductModel;

namespace SavanNah.DataAccess.Repositories.CategoryProducts;

public interface ICategoryProductRepository : IRepository<CategoryProduct>
{
    public CategoryProduct Update(CategoryProduct entity);
}