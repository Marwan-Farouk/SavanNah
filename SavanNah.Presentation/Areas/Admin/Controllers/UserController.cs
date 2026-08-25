using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavanNah.Models.Models.RoleModel;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<Models.Models.UserModel.User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<SavanNah.Models.Models.UserModel.User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
            //var user = await _userManager.FindByIdAsync("1");
            //user.UserName
        }
    }
}
