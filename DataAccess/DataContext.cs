
using Azure.Core;
using Domain.BaseClass;
using Domain.Models.Error;
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

        #region Error
        public DbSet<ErrorLog> ErrorLogs { get; set; }
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

            var passwordKey = new PasswordKey();
            string key = passwordKey.key;
            string iv = passwordKey.iv;
            var password = CryptoHelper.EncryptAES("syste@admin.lk", key, iv);
            modelBuilder.Entity<User>().HasData(new User {
                    Id = 1,
                    CreatedByUser = 1,
                    CreatedDate = DateTime.Now,
                    Email = password,
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