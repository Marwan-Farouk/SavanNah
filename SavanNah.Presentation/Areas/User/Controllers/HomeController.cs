using Microsoft.AspNetCore.Mvc;
using SavanNah.Models.Models;
using System.Diagnostics;

namespace SavanNah.Presentation.Areas.User.Controllers;

[Area("User")]
//[Route("Home/[action]")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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
