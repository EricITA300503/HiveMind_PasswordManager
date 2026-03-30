using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services;
using System.Linq;

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
        public IActionResult ToggleActive(string userId)
        {
            // Implementation depends on how you handle active/inactive states
            return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        public IActionResult ChangeRole(string userId, string newRole)
        {
            // Implementation uses _userManager.AddToRoleAsync and RemoveFromRoleAsync
            return RedirectToAction(nameof(UserList));
        }

        public IActionResult ActivityLog()
        {
            var logs = _logRepo.GetAllLogs();
            return View("AdminActivityLog", logs);
        }
    }
}