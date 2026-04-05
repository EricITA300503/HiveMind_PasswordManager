// ============================================================
// File:    DbSeeder.cs
// Author:  Miguel Lumaban
// Purpose: Seeds default Admin and User roles and creates
//          the default admin account on first run.
// ============================================================
using Microsoft.AspNetCore.Identity;
using PasswordManager.Models;

namespace PasswordManager.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (var role in new[] { "Admin", "User" })
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

            var admin = await userManager.FindByEmailAsync("admin@passwordmanager.ca");
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@passwordmanager.ca",
                    Email = "admin@passwordmanager.ca",
                    _fullName = "Administrator",
                };
                await userManager.CreateAsync(admin, "Admin@1234!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}

