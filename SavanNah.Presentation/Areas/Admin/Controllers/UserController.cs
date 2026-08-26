using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                Role = string.Join(",", _userManager.GetRolesAsync(user).Result.ToList()) // _userManager.GetRolesAsync(user).Result.First() ==> if only one role   
            }).ToList();

            return View(vms);
            
        }

    }
}
