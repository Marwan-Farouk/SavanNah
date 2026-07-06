using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var productVM = new CreateProductVM
        {
            Brands = await _productManager.GetBrands(),
            Categories = await _productManager.GetCategories()
        };
        return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductVM productVm)
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
    // [HttpGet]
    // public async Task<IActionResult> Edit(int id)
    // {
    //     // var prod = await _productManager.Get(p => p.Id == id);
    //     // if(prod is null)
    //     // {
    //     //     return NotFound();
    //     // }
    //     // return View(prod);
    // }
}