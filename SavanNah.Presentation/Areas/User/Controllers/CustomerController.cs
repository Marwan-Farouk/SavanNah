using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SavanNah.Models.ViewModels;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class CustomerController : Controller
    {
        private readonly UserManager<Models.Models.UserModel.User> _userManager;

        public CustomerController(UserManager<SavanNah.Models.Models.UserModel.User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Profile(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is not null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var vm = new UserVM
                {
                    Name = user.UserName!,
                    Email = user.Email!,
                    Role = string.Join(" - ", roles.ToList())
                };
                return View(vm);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
