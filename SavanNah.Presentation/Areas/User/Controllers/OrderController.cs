using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.OrderManager;
using SavanNah.Models.ViewModels;
using System.Security.Claims;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        [HttpPost]
        public IActionResult Create(List<CartItemVm> cartItems)
        {
            return Ok();
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
