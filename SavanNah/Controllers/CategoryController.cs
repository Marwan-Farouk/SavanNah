using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavanNah.Contexts;
using SavanNah.Models;

namespace SavanNah.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("CategoryIndex", await context.Categories.OrderBy(c => c.DisplayOrder).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name is not null && category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can't match the display Order");
            }
            if (category.Name is not null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "'Test' Is an Invalid Value");
            }

            if (ModelState.IsValid)
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }
    }
}
