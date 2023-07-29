using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using Domain.Models.Security;
using MediatR;


namespace Application.Features.Security.Users.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var updateUser = new User
            {

                Name = request.UserName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                IsDelete = request.IsDelete,
                IsActive = request.IsActive,
                UpdateByUser = request.UpdateByUser,
                UpdateDate = request.UpdateDate,

            };
            await _userRepository.UpdateUser(updateUser);
            return updateUser;
        }
    }
}
