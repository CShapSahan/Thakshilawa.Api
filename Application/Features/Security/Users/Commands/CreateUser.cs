using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.Commands
{
    public class CreateUser: IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsAdminPasswordRest { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
    }
}
