
using Domain.Models.SchoolStudent;
using Domain.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region Admin
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Student
        public DbSet<Student> Students { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddAdminData(modelBuilder);
        }

        private void AddAdminData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
                {
                    Id = 1,
                    Name = "SystemAdmin",                    
                });

            modelBuilder.Entity<User>().HasData(new User {
                    Id = 1,
                    CreatedByUser = 1,
                    CreatedDate = DateTime.Now,
                    Email = "syste@admin.lk",
                    IsAdminPasswordRest = false,
                    Name = "SystemAdmin",
                    Password = "Admin@123",
                    UserName = "admin_01",
                    IsActive = true,
                });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
            });
        }
    }
}