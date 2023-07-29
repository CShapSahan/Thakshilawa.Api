using Application.Abstractions.Security;
using Application.Features.SchoolStudent.Students.Queries;
using Application.Features.Security.Users.Queries;
using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.QueriesHandlers
{
    public class GetAllUsersHandeler : IRequestHandler<GetAllUsers, ICollection<User>>
    {
        public readonly IUserRepository _userRepository;
        public GetAllUsersHandeler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<ICollection<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
