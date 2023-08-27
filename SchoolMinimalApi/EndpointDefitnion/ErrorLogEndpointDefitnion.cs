using Application.Features.Error.CommandHandlers;
using Application.Features.Error.Queries;
using Application.Features.Security.Users.Commands;
using Application.Features.Security.Users.Queries;
using Domain.Models.Error;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SchoolMinimalApi.Abstractions;
using SchoolMinimalApi.Extensions;

namespace SchoolMinimalApi.EndpointDefitnion
{
    public class ErrorLogEndpointDefitnion : IEndpointDefitnion
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var userMap = app.MapGroup("/api/errorLog");
            CreateErrorLog createErrorLog;

            userMap.MapGet("/getAllError", async (IMediator mediator ) =>
            {
                var allErros = new GetAllErrors();
                var errorLogs = await mediator.Send(allErros);
                return Results.Ok(errorLogs);
            }).WithName("GetAllError").WithTags("Error Log");

            userMap.MapPost("/addNewError", async (IMediator mediator, CreateErrorLog createErrorLog) =>
            {                
                var newError = await mediator.Send(createErrorLog);
                return Results.NoContent();
            }).WithName("AddNewError").WithTags("Error Log");      

        }
       
    }
}
