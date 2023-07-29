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
    public class GetUserByIdHandeler : IRequestHandler<GetUserById, User>
    {
        public readonly IUserRepository _userRepository;
        public GetUserByIdHandeler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.Id);
        }
    }
}
