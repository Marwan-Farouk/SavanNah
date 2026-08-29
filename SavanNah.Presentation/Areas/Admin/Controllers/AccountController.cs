using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SavanNah.Models.ActionRequests;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<SavanNah.Models.Models.UserModel.User> _userManager;
        private readonly SignInManager<SavanNah.Models.Models.UserModel.User> _signInManager;

        public AccountController(UserManager<SavanNah.Models.Models.UserModel.User> userManager,
            SignInManager<SavanNah.Models.Models.UserModel.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login([FromQuery] string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginActionRequest request, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is not null)
                {
                    var passValid = await _userManager.CheckPasswordAsync(user, request.Password);
                    if (passValid)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: request.RememberMe);
                        if (returnUrl is not null)
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("Invalid Credintials", "Email or Password is incorrect");
            }

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User.Identity!.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterActionRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = new Models.Models.UserModel.User
                {
                    Id = Guid.NewGuid(),
                    UserName = request.Name,
                    Email = request.Email,
                    PasswordHash = request.Password
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }

            return View(request);
        }

        [HttpGet]
        public IActionResult DeniedAccess()
        {
            return View();
        }
    }
}
