using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Models.Models.ErrorViewModel;
using System.Diagnostics;

namespace SavanNah.Presentation.Areas.User.Controllers;

[Area("User")]
public class HomeController : Controller
{
    private readonly IProductManager _productManager;

    public HomeController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productManager.GetAll(p => true, ["Brand", "CategoryProducts.Category"]);
        var featured = products.Take(8).ToList();
        return View(featured);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
