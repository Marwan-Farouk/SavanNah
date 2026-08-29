using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SavanNah.Models.ActionRequests;
using SavanNah.Models.Models.RoleModel;
using SavanNah.Models.ViewModels;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<Models.Models.UserModel.User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<SavanNah.Models.Models.UserModel.User> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var vms = users.Select(user => new UserVM
            {
                Id = user.Id.ToString(),
                Name = user.UserName!,
                Email = user.Email!,
                Role = string.Join(",",
                    _userManager.GetRolesAsync(user).Result
                        .ToList()) // _userManager.GetRolesAsync(user).Result.First() ==> if only one role   
            }).ToList();

            return View(vms);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var request = new CreateUserActionRequest
            {
                Roles = roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList()
            };
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserActionRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = new SavanNah.Models.Models.UserModel.User
                {
                    Id = Guid.NewGuid(),
                    UserName = request.Name,
                    Email = request.Email,
                    PasswordHash = request.Password
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    if (!request.RoleNames.IsNullOrEmpty())
                    {
                        var roleResult = await _userManager.AddToRolesAsync(user, request.RoleNames!);
                        if (roleResult.Succeeded)
                            return RedirectToAction("Index", "User");

                        foreach (var error in roleResult.Errors)
                            ModelState.AddModelError(error.Code, error.Description);
                    }
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
            }

            var roles = await _roleManager.Roles.ToListAsync();
            request.Roles = roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList();
            return View(request);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is not null)
            {
                var result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
