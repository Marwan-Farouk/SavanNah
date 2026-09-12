using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.OrderManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Business.Managers.ShoppingCartManager;
using System.Security.Claims;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        private readonly IShoppingCartManager _shoppingCartManager;

        public OrderController(IOrderManager orderManager, IProductManager productManager, IShoppingCartManager shoppingCartManager)
        {
            this._orderManager = orderManager;
            this._productManager = productManager;
            this._shoppingCartManager = shoppingCartManager;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{

        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateCheckoutSession(Order order)
        //{

        //}


        private Guid GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            return Guid.Parse(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}
