using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models;

namespace SavanNah.DataAccess.Repositories.Categories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
