using System.Threading.Tasks;
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
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var cat = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (cat is not null)
            {
                return View(cat);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name is not null && category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can't match the display Order");
            }
            if (category.Name is not null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "'Test' Is an Invalid Value");
            }
            if (category.Name is null)
            {
                ModelState.AddModelError("name", "The Name Can't be empty");
            }
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await context.Categories.FirstAsync(cat => cat.Id == id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
