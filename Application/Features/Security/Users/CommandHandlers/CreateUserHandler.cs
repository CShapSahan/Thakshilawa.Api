using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using Domain.Models.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Security.Users.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var newUser= new User{

                Name = request.UserName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                IsDelete = request.IsDelete,
                IsActive = request.IsActive,
                CreatedByUser = request.CreatedByUser,
                CreatedDate = request.CreatedDate,
                    
            };
            await _userRepository.InsertUser(newUser);
            return newUser;
        }
    }
}
