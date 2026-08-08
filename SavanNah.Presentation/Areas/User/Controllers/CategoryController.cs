using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.CategoryManager;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryManager.GetAll();
            return View(categories);
        }

        public async Task<IActionResult> GetCategoryProducts(int id)
        {
            var products = await _categoryManager.GetCategoryProducts(id);
            return Json(products);
        }
    }
}
