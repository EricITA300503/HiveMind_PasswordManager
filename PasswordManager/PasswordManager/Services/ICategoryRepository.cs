// ============================================================
// File:    ICategoryRepository.cs
// Author:  Benjamin Mathies
// Purpose: Repository interface for category data access.
// ============================================================
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategoriesForUser(string userId);
        Category? GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}