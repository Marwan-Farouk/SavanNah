using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.OrderManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Models.DTOs.Order;
using SavanNah.Models.ViewModels;
using System.Security.Claims;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;

        public OrderController(IOrderManager orderManager, IProductManager productManager)
        {
            this._orderManager = orderManager;
            this._productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<CartItemVm> cartItems)
        {
            var userId = GetUserId();

            var products = await _productManager
                .GetAll(prod => cartItems.Select(item => item.Product.Id).Contains(prod.Id), null);

            var total = products.Sum(prod => (prod.Price - (prod.Price * (prod.Discount / 100))) * (cartItems.First(item => item.Product.Id == prod.Id).count));

            var orderProducts = cartItems.Select(item => new CreateOrderProductDTO
            {
                ProductId = item.Product.Id,
                Count = item.count
            });

            var orderDto = new CreateOrderDTO
            {
                UserId = userId,
                Products = products.ToList(),
                TotalAmount = total,
                OrderProducts = orderProducts.ToList(),
            };
            bool success = await _orderManager.Create(orderDto);
            if (success)
            {
                return RedirectToAction("Clear", "Cart", new { area = "User" });
            }
            TempData["error"] = "Failed to submit your order";
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Index()
        {
            return View();
        }

        private Guid GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            return Guid.Parse(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
    }
}
