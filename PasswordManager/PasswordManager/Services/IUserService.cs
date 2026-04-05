// ============================================================
// File:    UserService.cs
// Author:  Eric Bertero
// Purpose: Admin user management. Wraps Identity's
//          UserManager for the admin panel.
// ============================================================
using PasswordManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    }
}