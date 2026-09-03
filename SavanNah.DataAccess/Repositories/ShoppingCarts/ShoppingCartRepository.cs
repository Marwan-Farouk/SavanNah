using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.CartModel;

namespace SavanNah.DataAccess.Repositories.ShoppingCarts
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
        }
    }
}
