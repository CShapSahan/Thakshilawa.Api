using Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Security
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task InsertUser(User user);

        Task DeleteUser(int id);

        Task UpdateUser(User user);
    }
}
