using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Data;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class VaultController : Controller
    {
        private readonly IVaultRepository _repo;
        private readonly IVaultService _vaultService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VaultController(IVaultRepository repo, IVaultService vaultService,
            UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _vaultService = vaultService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? search, int? catId)
        {
            var userId = _userManager.GetUserId(User)!;
            var entries = _vaultService.SearchEntries(userId, search, catId);
            return View(entries);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(VaultEntry entry)
        {
            if (!ModelState.IsValid) return View(entry);
            entry._userId = _userManager.GetUserId(User)!;
            await _vaultService.CreateEntryAsync(entry);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var entry = _vaultService.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entry = _vaultService.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VaultEntry entry)
        {
            if (!ModelState.IsValid) return View(entry);

            var existingEntry = _vaultService.GetEntryById(entry._entryId);
            if (existingEntry == null)
            {
                return NotFound();
            }

            existingEntry._siteName = entry._siteName;
            existingEntry._siteUrl = entry._siteUrl;
            existingEntry._username = entry._username;
            existingEntry._encryptedPassword = entry._encryptedPassword;
            existingEntry._notes = entry._notes;
            existingEntry._categoryId = entry._categoryId;
            existingEntry._userId = _userManager.GetUserId(User)!;

            await _vaultService.UpdateEntryAsync(existingEntry);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entry = _vaultService.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vaultService.DeleteEntryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}