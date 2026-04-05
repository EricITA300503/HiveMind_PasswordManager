// ============================================================
// File:    ICategoryService.cs
// Author:  Eric Bertero
// Purpose: Contract interface for category business logic.
// ============================================================
using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetUserCategories(string userId);
    }
}