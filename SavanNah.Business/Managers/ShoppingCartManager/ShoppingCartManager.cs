using SavanNah.DataAccess.Repositories.ShoppingCarts;
using SavanNah.Models.Models.CartModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.ShoppingCartManager
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartManager(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<bool> AddItem(ShoppingCart cartItem)
        {
            if (await _shoppingCartRepository.Create(cartItem) is not null)
                return true;
            return false;

        }

        public async Task<ShoppingCart> GetItem(Expression<Func<ShoppingCart, bool>> filter, string[]? includes)
        {
            return await _shoppingCartRepository.Get(filter, includes);
        }

        public async Task<IEnumerable<ShoppingCart>> GetUserCart(Guid userId)
        {
            return await _shoppingCartRepository.GetAll(sc => sc.UserId == userId, ["Product"]);
        }

        public async Task<bool> ClearUserCart(Guid userId)
        {
            return await _shoppingCartRepository.DeleteRange(sc => sc.UserId == userId);
        }

        public async Task<bool> RemoveItem(ShoppingCart cartItem)
        {
            return await _shoppingCartRepository.Delete(cartItem);
        }

        public async Task<bool> RemoveRange(Expression<Func<ShoppingCart, bool>> filter)
        {
            return await _shoppingCartRepository.DeleteRange(filter);
        }

        public async Task<int> Save()
        {
            return await _shoppingCartRepository.Save();
        }

        public ShoppingCart UpdateItem(ShoppingCart cartItem)
        {
            return _shoppingCartRepository.Update(cartItem);
        }
    }
}
