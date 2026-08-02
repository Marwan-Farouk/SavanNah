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
        var productVm = new ProductVM();
        productVm.AddBrands(brands, []);
        productVm.AddCategories(cats, []);

        return View(productVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductVM productVm, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            if (file is not null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var productPath = Path.Combine(wwwRootPath, "images/Products");
                await using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                productVm.Product.Image = "images/Products/" + fileName;
            }

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
        productVm.AddBrands(brands, []);
        productVm.AddCategories(cats, []);
        return View(productVm);
    }

    
}