// ============================================================
// File:    AccountController.cs
// Author:  Miguel Lumaban
// Purpose: Handles user registration, login, and logout.
//          Uses ASP.NET Core Identity and logs logins via
//          ActivityLogService.
// ============================================================using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Models.ViewModels;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IActivityLogService _logService;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IActivityLogService logService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logService = logService;
        }

        [HttpGet] public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email, _fullName = vm.FullName };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Login");
            }
            foreach (var err in result.Errors) ModelState.AddModelError("", err.Description);
            return View(vm);
        }

        [HttpGet] public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, false);
            if (result.Succeeded)
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                var user = await _userManager.FindByEmailAsync(vm.Email);
                await _logService.LogActionAsync(user!.Id, "Login", ip);
                return RedirectToAction("Index", "Vault");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
