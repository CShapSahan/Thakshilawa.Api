using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using Azure.Core;
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

        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var deleteUser = await _userRepository.GetUserById(request.Id);
            deleteUser.IsDelete = true;
            deleteUser.IsActive = !deleteUser.IsDelete;
            await _userRepository.UpdateUser(deleteUser);
            return Unit.Value;
        }
    }
}
