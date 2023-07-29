using Application.Abstractions.Security;
using Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            await _dataContext.AddAsync(user);
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
    }
}
