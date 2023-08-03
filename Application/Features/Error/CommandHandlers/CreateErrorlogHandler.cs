using Application.Abstractions.Error;
using Domain.Models.Error;
using MediatR;
using Microsoft.VisualBasic;

namespace Application.Features.Error.CommandHandlers
{
    public class CreateErrorlogHandler : IRequestHandler<CreateErrorLog>
    {
        private readonly IErrorLogRepository _errorRepository;

        public CreateErrorlogHandler(IErrorLogRepository errorRepository)
        {
            _errorRepository= errorRepository;
        }
        public async Task<Unit> Handle(CreateErrorLog request, CancellationToken cancellationToken)
        {
            var newError = new ErrorLog
            {
                ApiPath = request.ApiPath,
                DateTime = DateTime.Now,
                InnerException = request.InnerException,
                Message = request.Message,
                UserId = request.UserId,
            };
            await _errorRepository.AddError(newError);
            return Unit.Value;
        }
    }
}
