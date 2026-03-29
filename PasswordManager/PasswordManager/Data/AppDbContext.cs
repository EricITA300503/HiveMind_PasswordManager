using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;

namespace PasswordManager.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<VaultEntry> VaultEntries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VaultEntry>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v._userId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c._userId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ActivityLog>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a._userId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
