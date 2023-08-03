using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using Domain.BaseClass;
using Domain.Models.Security;
using MediatR;
using System.Security.Cryptography;

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
            var passwordKey = new PasswordKey();
            string key = passwordKey.key;
            string iv = passwordKey.iv;
            request.Password = CryptoHelper.EncryptAES(request.Password, key, iv);
           
            var newUser= new User{

                Name = request.UserName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                IsDelete = false,
                IsActive = false,
                CreatedByUser = request.CreatedByUser,
                CreatedDate = request.CreatedDate,
                    
            };
            await _userRepository.InsertUser(newUser);
            return newUser;
        }
    }
}
