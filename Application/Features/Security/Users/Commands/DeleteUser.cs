using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.Commands
{
    public class DeleteUser: IRequest
    {
        public int Id { get; set; }       
        
    }
}
