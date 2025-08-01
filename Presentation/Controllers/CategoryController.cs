using Business.Managers;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.VMs;

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _manager;
        public CategoryController(ICategoryManager manager)
        {
            _manager = manager;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cats = await _manager.GetAllCategories();
            var vMs = cats.Select(c => c.ToVMAll()).ToList();
            return View(vMs);
        }

    }
}
