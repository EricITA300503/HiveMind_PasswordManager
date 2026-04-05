// ============================================================
// File:    CategoryService.cs
// Author:  Eric Bertero
// Purpose: Business logic for category management.
//          Delegates to ICategoryRepository.
// ============================================================
using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Category> GetUserCategories(string userId)
        {
            return _repo.GetCategoriesForUser(userId);
        }
    }
}