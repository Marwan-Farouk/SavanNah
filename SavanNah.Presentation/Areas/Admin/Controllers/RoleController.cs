using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavanNah.Models.Models.RoleModel;

namespace SavanNah.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<Models.Models.UserModel.User> _userManager;

    public RoleController(RoleManager<Role> roleManager, UserManager<SavanNah.Models.Models.UserModel.User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        // var users = await _userManager.Users.ToListAsync();
        return View(roles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Role request)
    {
        if (ModelState.IsValid)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            var success = await _roleManager.CreateAsync(role);
            if (success.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in success.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }

        return View(request);
    }
}