using Application.Features.Security.Users.Commands;
using Application.Features.Security.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SchoolMinimalApi.Abstractions;

namespace SchoolMinimalApi.EndpointDefitnion
{
    public class UserEndpointDefitnion : IEndpointDefitnion
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var userMap = app.MapGroup("/api/user");

            userMap.MapGet("/GetUserById", async (IMediator mediator, int id) =>
            {
                var getUser = new GetUserById { Id = id };
                var user = await mediator.Send(getUser);
                return Results.Ok(user);
            }).WithName("GetUserById");

            userMap.MapGet("/GetAllUsers", async (IMediator mediator ) =>
            {
                var getUsers = new GetAllUsers();
                var users = await mediator.Send(getUsers);
                return Results.Ok(users);
            }).WithName("GetAllUsers").RequireAuthorization("SystemAdmin"); ;

            userMap.MapPost("/createUser", async (IMediator mediator, CreateUser createUser) =>
            {

                var createdUser = await mediator.Send(createUser);
                return Results.CreatedAtRoute("GetUserById", new { createdUser.Id }, createdUser);
            });

            userMap.MapPost("/updateUser", async (IMediator mediator, UpdateUser updateUser) =>
            {

                var updatedUser = await mediator.Send(updateUser);
                return Results.CreatedAtRoute("GetUserById", new { updatedUser.Id }, updatedUser);
            });

            userMap.MapPost("/deleteUser", async (IMediator mediator, DeleteUser deleteUser) =>
            {

                var updatedUser = await mediator.Send(deleteUser);
                return Results.NoContent();
            });

            userMap.MapGet("/NewErrorTest",  () =>
            {
                throw new Exception("An Error Occurred...");
            }).WithName("NewErrorTest");
        }
    }
}
