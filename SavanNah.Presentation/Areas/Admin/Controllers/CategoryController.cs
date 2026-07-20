using Microsoft.AspNetCore.Mvc;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.Models.Models.CategoryModel;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("CategoryIndex", await _repository.GetAll(c => true, []));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.Description)
            {
                ModelState.AddModelError("name", "The Name Can't match the Description");
            }

            if (category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "'Test' Is an Invalid Value");
            }

            if (ModelState.IsValid)
            {
                var createdCategory = await _repository.Create(category);
                if (createdCategory is not null)
                    TempData["success"] = "Category created successfully";
                else
                    TempData["error"] = "Couldn't Create Category";
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
            var cat = await _repository.Get(c => c.Id == id, []);
            if (cat is null)
                return NotFound();
            else
                return View(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name is not null && category.Name == category.Description)
            {
                ModelState.AddModelError("name", "The Name Can't match the Description");
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
                var updated = _repository.Update(category);
                if (updated is not null)
                    TempData["success"] = "Category Updated successfully";
                else
                    TempData["error"] = "Couldn't Update Category";

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
            var category = await _repository.Get(cat => cat.Id == id, []);

            var success = await _repository.Delete(category);
            if (success)
                TempData["success"] = "Category Deleted successfully";
            else
                TempData["error"] = "Couldn't Delete Category";

            return RedirectToAction(nameof(Index));
        }
    }
}
