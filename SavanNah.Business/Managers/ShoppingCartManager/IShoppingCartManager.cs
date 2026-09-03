using SavanNah.Models.Models.CartModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.ShoppingCartManager
{
    public interface IShoppingCartManager
    {
        public Task<ShoppingCart> GetItem(Expression<Func<ShoppingCart, bool>> filter, string[]? includes);
        public Task<IEnumerable<ShoppingCart>> GetUserCart(Guid userId);
        public Task<bool> AddItem(ShoppingCart cartItem);
        public Task<bool> RemoveItem(ShoppingCart cartItem);
        public Task<bool> RemoveRange(Expression<Func<ShoppingCart, bool>> filter);
        public ShoppingCart UpdateItem(ShoppingCart cartItem);
        public Task<int> Save();
    }
}
