using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ispit.Books.Models;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedUsers(builder);
            SeedData(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var userId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();

            // Seed Admin Role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Seed Admin User
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = userId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password12345"),
                SecurityStamp = string.Empty
            };

            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Seed Admin User Role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Author1" },
                new Author { Id = 2, Name = "Author2" },
                new Author { Id = 3, Name = "Author3" },
                new Author { Id = 4, Name = "Author4" },
                new Author { Id = 5, Name = "Author5" }
            );

            builder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Publisher1" },
                new Publisher { Id = 2, Name = "Publisher2" },
                new Publisher { Id = 3, Name = "Publisher3" }
            );
        }
    }
}



