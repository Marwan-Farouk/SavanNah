using Microsoft.AspNetCore.Mvc;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.Models.Models.BrandModel;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await brandRepository.GetAll(b => true, []);
            return View(brands.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var createdBrand = await brandRepository.Create(brand);
                if (createdBrand is not null)
                    TempData["success"] = "Brand Was Created Successfully";
                else
                    TempData["error"] = "Couldn't Create Brand";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(brand);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var brand = await brandRepository.Get(b => b.Id == id, []);
            if (brand is not null)
                return View(brand);
            else
            {
                TempData["error"] = "Couldn't Find Brand";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var updated = brandRepository.Update(brand);
                if (updated is not null)
                    TempData["success"] = "Brand Was Updated Successfully";
                else
                    TempData["error"] = "Couldn't Update Brand";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(brand);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var brand = await brandRepository.Get(b => b.Id == id, []);
            if (brand is not null)
            {
                var success = await brandRepository.Delete(brand);
                if (success)
                    TempData["success"] = "Brand Was Deleted Successfully";
                else
                    TempData["error"] = "Couldn't Delete Brand";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Couldn't Find Brand";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
