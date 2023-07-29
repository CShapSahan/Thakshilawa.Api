using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.Queries
{
    public class GetAllUsers :IRequest<ICollection<User>>
    {
    }
}
