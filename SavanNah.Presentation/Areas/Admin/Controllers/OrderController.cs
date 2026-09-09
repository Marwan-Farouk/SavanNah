using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.OrderManager;
using System.Text.Json.Serialization;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly UserManager<Models.Models.UserModel.User> _userManager;

        public OrderController(IOrderManager orderManager, UserManager<SavanNah.Models.Models.UserModel.User> userManager)
        {
            this._orderManager = orderManager;
            this._userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderManager.GetAll(includes: ["User"]);
            return View(orders.ToList());
        }

        public async Task<IActionResult> GetOrdersData()
        {
            var orders = await _orderManager.GetAll(null, ["User"]);
            var options = new System.Text.Json.JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            return Json(orders.ToList(), options);
        }
    }
}
