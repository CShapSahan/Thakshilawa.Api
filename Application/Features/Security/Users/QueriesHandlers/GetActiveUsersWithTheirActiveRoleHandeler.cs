using Application.Abstractions.Security;
using Application.Features.Security.Users.Queries;
using Domain.DTO.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.QueriesHandlers
{
    public class GetActiveUsersWithTheirActiveRoleHandeler:IRequestHandler<GetActiveUsersWithTheirActiveRole, AllActiveUsersWithTheirActiveRole?>
    {
        public readonly IUserRepository _userRepository;
        public GetActiveUsersWithTheirActiveRoleHandeler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AllActiveUsersWithTheirActiveRole?> Handle(GetActiveUsersWithTheirActiveRole request, CancellationToken cancellationToken)
        {
            return await _userRepository.GatActiveUserWithRole(request.UserName, request.Password);
        }
    }
}
