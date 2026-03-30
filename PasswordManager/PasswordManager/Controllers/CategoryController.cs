using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryRepository _repo;

        public CategoryController(UserManager<ApplicationUser> userManager, ICategoryRepository repo)
        {
            _userManager = userManager;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User)!;
            var categories = _repo.GetCategoriesForUser(userId);
            return View("CategoryList", categories);
        }

        public IActionResult Create() => View("CategoryCreate");

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View("CategoryCreate", category);

            category._userId = _userManager.GetUserId(User)!;
            _repo.Add(category);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var category = _repo.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _repo.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}