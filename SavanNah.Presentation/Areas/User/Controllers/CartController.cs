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
    [Authorize]
    public class CartController : Controller
    {
        private readonly IShoppingCartManager _shoppingCartManager;

        public CartController(IShoppingCartManager shoppingCartManager, UserManager<SavanNah.Models.Models.UserModel.User> userManager)
        {
            this._shoppingCartManager = shoppingCartManager;

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromQuery] int id, [FromQuery] int count)
        {
            var userId = GetUserId();
            var cartItem = await _shoppingCartManager.GetItem(sc => sc.UserId == userId && sc.ProductId == id, null);
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
                    UserId = userId
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
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var userCartItems = await _shoppingCartManager.GetUserCart(userId); // product object is included
            var cartItemVms = userCartItems.Select(item => new CartItemVm
            {
                Product = item.Product,
                count = item.Count,
            });
            return View(cartItemVms);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, int newCount)
        {
            var userId = GetUserId();
            var item = await _shoppingCartManager.GetItem(sc => sc.ProductId == id && sc.UserId == userId, null);
            item.Count = newCount;
            var updatedItem = _shoppingCartManager.UpdateItem(item);
            await _shoppingCartManager.Save();
            if (updatedItem is not null)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {
            var userId = GetUserId();
            var cartItem = await _shoppingCartManager.GetItem(sc => sc.ProductId == id && sc.UserId == userId, null);

            if (cartItem is not null)
            {
                bool success = await _shoppingCartManager.RemoveItem(cartItem);
                if (success)
                {
                    await _shoppingCartManager.Save();
                    return Ok();
                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> Clear()
        {
            var userId = GetUserId();

            var success = await _shoppingCartManager.ClearUserCart(userId);
            if (!success)
            {
                return BadRequest();
            }
            await _shoppingCartManager.Save();
            return View(nameof(Index));

        }

        private Guid GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            return Guid.Parse(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}
