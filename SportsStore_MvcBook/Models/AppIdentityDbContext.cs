using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsStore_MvcBook.Models.Identity;
using System;

namespace SportsStore_MvcBook.Models
{
    public class AppIdentityDbContext : IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Создаем роль администратора
            IdentityRole adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            // Создаем пользователя Администратора
            User adminUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@lol",
                NormalizedEmail = "ADMIN@LOL",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "qwerty"),
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };

            // Заносим роль в БД
            builder.Entity<IdentityRole>().HasData(adminRole);

            // Заносим пользователя в БД
            builder.Entity<User>().HasData(adminUser);

            // Пользователю Administrator присваиваем роль admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            });
        }
    }
}
