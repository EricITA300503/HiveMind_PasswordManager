using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetUserCategories(string userId);
    }
}