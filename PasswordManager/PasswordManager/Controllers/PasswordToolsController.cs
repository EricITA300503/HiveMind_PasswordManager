// ============================================================
// File:    PasswordToolsController.cs
// Author:  Benjamin Mathies
// Purpose: MVC controller for the password generator page.
// ============================================================
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models.ViewModels;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{

    [Authorize]
    public class PasswordToolsController : Controller
    {
        private readonly IPasswordService _passwordService;

        public PasswordToolsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult Generator()
        {
            return View(new PasswordOptions());
        }

        [HttpPost]
        public IActionResult Generator(PasswordOptions options)
        {
            var generatedPassword = _passwordService.GeneratePassword(options);
            var strength = _passwordService.EvaluateStrength(generatedPassword);

            ViewBag.GeneratedPassword = generatedPassword;
            ViewBag.StrengthLabel = strength.Label;
            ViewBag.StrengthScore = strength.Score;

            return View(options);
        }
    }
}