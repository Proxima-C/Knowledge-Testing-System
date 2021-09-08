using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Authorization.Models
{
    public static class IdentityModelBuilderExtensions
    {
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
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "1aa9cfc9-f6bf-4a28-a2f4-4e46a0555aa0"
                }
            );
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }

        private static void SeedApplicationUsers(ModelBuilder modelBuilder)
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = "1aa9cfc9-f6bf-4a28-a2f4-4e46a0555aa0",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.PasswordHash = passwordHasher.HashPassword(user, "12345");

            modelBuilder.Entity<ApplicationUser>().HasData(user);
        }
    }
}
