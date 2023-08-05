using Application.Features.Error.CommandHandlers;
using DataAccess;
using DataAccess.Repository.Error;
using Domain.Models.Error;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SchoolMinimalApi.Extensions
{
    public class ErrorLogCreator
    {
        private readonly IMediator _mediator;
        public ErrorLogCreator(IMediator mediator)
        {
            _mediator=mediator;
        }
        public async Task AddError(CreateErrorLog createErrorLog)
        {
            var newError = await _mediator.Send(createErrorLog);
        }
    }
}
