using Application.Features.Error.CommandHandlers;
using MediatR;

namespace SchoolMinimalApi.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public readonly IMediator _mediator;
        public ExceptionHandlingMiddleware(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                var createErrorLog = new CreateErrorLog
                {
                    Message = ex.Message,
                    ApiPath = context.Request.Path,
                    InnerException = innerException
                };
                await _mediator.Send(createErrorLog);
                throw new Exception("Error: An unexpected issue has occurred. Please review the error log for further details.");
            }
        }
    }
}
