using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.ShoppingCartManager;
using SavanNah.Models.Models.CartModel;
using SavanNah.Models.ViewModels;
using System.Security.Claims;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class CartController : Controller
    {
        private readonly IShoppingCartManager _shoppingCartManager;
        private readonly UserManager<Models.Models.UserModel.User> _userManager;

        public CartController(IShoppingCartManager shoppingCartManager, UserManager<SavanNah.Models.Models.UserModel.User> userManager)
        {
            this._shoppingCartManager = shoppingCartManager;
            this._userManager = userManager;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromQuery] int id, [FromQuery] int count)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var userId = claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var cartItem = await _shoppingCartManager.GetItem(sc => sc.UserId.ToString() == userId && sc.ProductId == id, null);
            bool success;
            if (cartItem is not null)
            {
                cartItem.Count = cartItem.Count + count;
                var updatedItem = _shoppingCartManager.UpdateItem(cartItem);
                await _shoppingCartManager.Save();
                success = (updatedItem is not null);
            }
            else
            {
                var item = new ShoppingCart
                {
                    ProductId = id,
                    Count = count,
                    UserId = Guid.Parse(userId)
                };
                success = await _shoppingCartManager.AddItem(item);
                await _shoppingCartManager.Save();
            }
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var userCartItems = await _shoppingCartManager.GetUserCart(id); // product object is included
            var cartItemVms = userCartItems.Select(item => new CartItemVm
            {
                Product = item.Product,
                count = item.Count,
            });
            return View(cartItemVms);
        }
    }
}
