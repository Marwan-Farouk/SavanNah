using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.DTOs.Products;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Models.ViewModels;

namespace SavanNah.Presentation.Areas.User.Controllers;

[Area("User")]
public class ProductController : Controller
{
    private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var prods = await _productManager.GetAll(null);
        return View(prods.ToList());
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var productVM = new ProductVM
        {
            Brands = await _productManager.GetBrands(),
            Categories = await _productManager.GetCategories()
        };
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

        productVm.Brands = await _productManager.GetBrands();
        productVm.Categories = await _productManager.GetCategories();
        return View(productVm);
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _productManager.Get(p => p.Id == id);
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
        var prod = await _productManager.Get(p => p.Id == id);
        if (prod is null)
        {
            return NotFound();
        }
        var productVM = new ProductVM
        {
            Product = prod,
            Brands = await _productManager.GetBrands(),
            Categories = await _productManager.GetCategories()
        };

        return View(productVM);
    }
}