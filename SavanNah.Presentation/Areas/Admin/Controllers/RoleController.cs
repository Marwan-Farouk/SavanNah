using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavanNah.Models.Models.RoleModel;
using SavanNah.Models.ViewModels;

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

    [HttpGet]
    public async Task<IActionResult> AssignRole()
    {
        var users = await _userManager.Users.ToListAsync();
        var roles = await _roleManager.Roles.ToListAsync();

        var vm = new UserRoleVM()
        {
            Users = users.Select(user => new SelectListItem { Value = user.Id.ToString(), Text = user.UserName })
                .ToList(),
            Roles = roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList()
        };

        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> AssignRole(UserRoleVM request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null)
        {
            ModelState.AddModelError("User", "User is invalid");
            return View(request);
        }

        if (ModelState.IsValid)
        {

            var result = await _userManager.AddToRolesAsync(user, request.RoleNames);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }

        var users = await _userManager.Users.ToListAsync();
        var roles = await _roleManager.Roles.ToListAsync();

        request.Users = users.Select(user => new SelectListItem { Value = user.Id.ToString(), Text = user.UserName })
                .ToList();
        request.Roles = roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList();

        return View(request);

    }



}