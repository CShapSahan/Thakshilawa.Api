using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using Domain.Models.Security;
using MediatR;

namespace Application.Features.Security.Users.CommandHandlers
{
    public class DeletUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly IUserRepository _userRepository;
        public DeletUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var deleteUser =await _userRepository.GetUserById(request.Id);
            deleteUser.IsDelete = true;
            deleteUser.IsActive = !deleteUser.IsDelete;
            await _userRepository.UpdateUser(deleteUser);
        }
    }
}
