using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.Commands
{
    public class UpdateUser: IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsAdminPasswordRest { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? UpdateByUser { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        
    }
}
