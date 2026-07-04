using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.CategoryProductModel;

namespace SavanNah.DataAccess.Repositories.CategoryProducts;

public class CategoryProductRepository : Repository<CategoryProduct>, ICategoryProductRepository
{
    public CategoryProductRepository(AppDbContext context) : base(context)
    {
    }
}