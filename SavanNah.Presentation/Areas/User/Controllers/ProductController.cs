using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.BrandManager;
using SavanNah.Business.Managers.CategoryManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Models.DTOs.Products;
using SavanNah.Models.ViewModels;

namespace SavanNah.Presentation.Areas.User.Controllers;

[Area("User")]
public class ProductController : Controller
{
    private readonly IProductManager _productManager;
    private readonly IBrandManager _brandManager;
    private readonly ICategoryManager _categoryManager;

    public ProductController(IProductManager productManager, IBrandManager brandManager, ICategoryManager categoryManager)
    {
        _productManager = productManager;
        this._brandManager = brandManager;
        this._categoryManager = categoryManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var prods = await _productManager.GetAll(p => true, ["Brand", "CategoryProducts.Category"]);
        return View(prods.ToList());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var brands = await _brandManager.GetAll(b => true, []);
        var cats = await _categoryManager.GetAll(c => true, []);
        var productVM = new ProductVM();
        productVM.AddBrands(brands);
        productVM.AddCategories(cats);

        return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductVM productVm)
    {
        if (ModelState.IsValid)
        {
            var created = await _productManager.Create(CreateProductDTO.ToDTO(productVm));
            if (created)
            {
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Failed to create product";
            }
        }
        var brands = await _brandManager.GetAll(b => true, []);
        var cats = await _categoryManager.GetAll(c => true, []);
        productVm.AddBrands(brands);
        productVm.AddCategories(cats);
        return View(productVm);
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _productManager.Get(p => p.Id == id, []);
        if (product is not null)
        {
            var success = await _productManager.Delete(product);
            if (success)
                TempData["success"] = "Product Deleted successfully";
            else
                TempData["error"] = "Couldn't Delete Product";

            return RedirectToAction(nameof(Index));
        }
        else
        {
            TempData["error"] = "Product Was not found";
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var prod = await _productManager.Get(p => p.Id == id, []);
        if (prod is null)
        {
            return NotFound();
        }
        var brands = await _brandManager.GetAll(b => true, []);
        var cats = await _categoryManager.GetAll(c => true, []);
        var productVM = new ProductVM
        {
            Product = prod,
        };
        productVM.AddBrands(brands);
        productVM.AddCategories(cats);
        return View(productVM);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductVM productVm)
    {
        if (ModelState.IsValid)
        {
            var productDto = UpdateProductDTO.ToDTO(productVm);
            var updated = await _productManager.Update(productDto);
            if (updated is not null)
                TempData["success"] = "Product Updated Successfuly";
            else
                TempData["error"] = "Couldn't Update Product";

            return RedirectToAction(nameof(Index));
        }
        var brands = await _brandManager.GetAll(b => true, []);
        var cats = await _categoryManager.GetAll(c => true, []);
        productVm.AddBrands(brands);
        productVm.AddCategories(cats);
        return View(productVm);
    }
}