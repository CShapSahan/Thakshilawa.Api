using Application.Abstractions.Security;
using Azure.Core;
using Domain.BaseClass;
using Domain.DTO.Security;
using Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Security
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _dataContext;   
        
        public UserRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _dataContext.Users.Where(x=>x.IsDelete == false).ToListAsync();
        }

        public async Task<User> GetUserById(int id) => await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task InsertUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var deleteUser =  await GetUserById(id);
           _dataContext.Users.Remove(deleteUser);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }
           

        public async Task<AllActiveUsersWithTheirActiveRole?> GatActiveUserWithRole(string userName, string password)
        {
            var passwordKey = new PasswordKey();
            string key = passwordKey.key;
            string iv = passwordKey.iv;
            var encriptPsw = CryptoHelper.EncryptAES(password, key, iv);

            var allActiveUserWithRole = (from user in _dataContext.Users
                                         join userRole in _dataContext.UserRoles on user.Id equals userRole.UserId
                                         join role in _dataContext.Roles on userRole.RoleId equals role.Id
                                         where user.IsActive == true && userRole.IsActive == true
                                         && user.UserName == userName
                                         && user.Password == encriptPsw
                                         select new AllActiveUsersWithTheirActiveRole
                                         {
                                             RoleId = role.Id,
                                             RoleName = role.Name,
                                             UserId = user.Id,
                                             UserName = user.UserName,
                                         }).FirstOrDefaultAsync();
            return await allActiveUserWithRole;
        }
    }
}
