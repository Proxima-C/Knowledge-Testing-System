using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Models
{
    public static class IdentityModelBuilderExtensions
    {
        private static readonly string AdminId = "1aa9cfc9-f6bf-4a28-a2f4-4e46a0555aa0";
        private static readonly string AdminRoleId = "46396fb8-c21e-4f83-ba5b-eda06c3cb9ac";

        private static readonly string AppUserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        private static readonly string AppUserRoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedApplicationUsers(modelBuilder);

            SeedRoles(modelBuilder);

            SeedUserRoles(modelBuilder);
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = AdminRoleId,
                    UserId = AdminId
                },
                new IdentityUserRole<string>()
                {
                    RoleId = AppUserRoleId,
                    UserId = AppUserId
                }
            );
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = AdminRoleId, Name = "Admin", ConcurrencyStamp = AdminRoleId, NormalizedName = "Admin".ToUpper() },
                new IdentityRole() { Id = AppUserRoleId, Name = "User", ConcurrencyStamp = AppUserRoleId, NormalizedName = "User".ToUpper() }
            );
        }

        private static void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            AppUser admin = new AppUser
            {
                Id = AdminId,
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin".ToUpper(),
                NormalizedEmail = "admin@gmail.com".ToUpper(),
            };

            AppUser user = new AppUser
            {
                Id = AppUserId,
                UserName = "user",
                Email = "user@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "user".ToUpper(),
                NormalizedEmail = "user@gmail.com".ToUpper(),
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "12345");
            user.PasswordHash = passwordHasher.HashPassword(user, "55555");

            modelBuilder.Entity<AppUser>().HasData(admin, user);
        }
    }
}
