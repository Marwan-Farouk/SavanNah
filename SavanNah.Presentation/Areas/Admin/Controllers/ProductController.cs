using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.BrandManager;
using SavanNah.Business.Managers.CategoryManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Models.DTOs.Products;
using SavanNah.Models.ViewModels;
using System.Text.Json.Serialization;

namespace SavanNah.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IProductManager _productManager;
    private readonly IBrandManager _brandManager;
    private readonly ICategoryManager _categoryManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IProductManager productManager, IBrandManager brandManager,
        ICategoryManager categoryManager, IWebHostEnvironment webHostEnvironment)
    {
        _productManager = productManager;
        this._brandManager = brandManager;
        this._categoryManager = categoryManager;
        _webHostEnvironment = webHostEnvironment;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var prods = await _productManager.GetAll(p => true, ["Brand", "CategoryProducts.Category"]);
        var options = new System.Text.Json.JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        return Json(prods, options);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var prods = await _productManager.GetAll(p => true, ["Brand", "CategoryProducts.Category"]);
        return View(prods.ToList());
    }


    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _productManager.Get(p => p.Id == id, []);
        if (product is not null)
        {
            var success = await _productManager.Delete(product);
            if (success)
            {
                if (!String.IsNullOrEmpty(product.Image))
                {
                    var wwwroot = _webHostEnvironment.WebRootPath;
                    var ImageToDelete = Path.Combine(wwwroot, product.Image);
                    if (System.IO.File.Exists(ImageToDelete))
                    {
                        System.IO.File.Delete(ImageToDelete);
                    }
                }
            }

            return Json(new { success = true, message = "Your Product has been deleted." });
        }
        else
        {
            TempData["error"] = "Product Was not found";
            return Json(new { success = false, message = "Couldn't delete your Product." });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var prod = await _productManager.Get(p => p.Id == id, new[] { "CategoryProducts" });
        if (prod is null)
        {
            return NotFound();
        }

        var brands = await _brandManager.GetAll(b => true, Array.Empty<string>());
        var cats = await _categoryManager.GetAll(c => true, Array.Empty<string>());
        var productVM = new ProductVM { Product = prod };

        var selectedCategoryIds = prod.CategoryProducts.Select(cp => cp.CategoryId).ToArray() ?? Array.Empty<int>();

        productVM.CategoryIds = selectedCategoryIds.ToList();
        productVM.AddBrands(brands, new[] { prod.BrandId });
        productVM.AddCategories(cats, selectedCategoryIds);
        return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductVM productVm, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            if (file is not null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var productPath = Path.Combine(wwwRootPath, @"images/Products");
                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                if (!string.IsNullOrEmpty(productVm.Product.Image))
                {
                    var oldImage = Path.Combine(wwwRootPath, productVm.Product.Image);
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                productVm.Product.Image = "images/products/" + fileName;
            }
            productVm.Product.Image = string.Empty;
            var productDto = UpdateProductDTO.VmToDto(productVm);
            var updated = await _productManager.Update(productDto);
            if (updated is not null)
                TempData["success"] = "Product Updated Successfuly";
            else
                TempData["error"] = "Couldn't Update Product";

            return RedirectToAction(nameof(Index));
        }

        var brands = await _brandManager.GetAll(b => true, Array.Empty<string>());
        var cats = await _categoryManager.GetAll(c => true, Array.Empty<string>());

        var selectedCategoryIds = productVm.Product.CategoryProducts.Select(cp => cp.CategoryId).ToArray() ??
                                  Array.Empty<int>();

        productVm.CategoryIds = selectedCategoryIds.ToList();
        productVm.AddBrands(brands, new[] { productVm.Product.BrandId });
        productVm.AddCategories(cats, selectedCategoryIds);
        return View(productVm);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductPartial(int id)
    {
        var prod = await _productManager.Get(p => p.Id == id, ["Brand", "CategoryProducts.Category"]);
        var vm = new ProductVM
        {
            Product = prod
        };
        return PartialView("_ProductPartial", vm);
    }
}