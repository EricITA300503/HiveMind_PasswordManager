// ============================================================
// File:    AdminController.cs
// Author:  Eric Bertero
// Purpose: MVC controller for the admin panel. Manages user
//          accounts and activity log. Admin role only.
// ============================================================
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManager.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IActivityLogRepository _logRepo;

        public AdminController(UserManager<ApplicationUser> userManager, IActivityLogRepository logRepo)
        {
            _userManager = userManager;
            _logRepo = logRepo;
        }

        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View("AdminUserList", users);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleActive(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (await _userManager.IsLockedOutAsync(user))
                {
                    await _userManager.SetLockoutEndDateAsync(user, null); // Unlock
                }
                else
                {
                    await _userManager.SetLockoutEndDateAsync(user, System.DateTimeOffset.MaxValue); // Lock
                }
            }
            return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !string.IsNullOrEmpty(newRole))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, newRole);
            }
            return RedirectToAction(nameof(UserList));
        }

        public IActionResult ActivityLog()
        {
            var logs = _logRepo.GetAllLogs();
            return View("AdminActivityLog", logs);
        }
    }
}