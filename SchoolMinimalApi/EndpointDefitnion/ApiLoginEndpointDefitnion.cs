using Application.Features.Security.Users.Queries;
using Application.Services;
using Domain.BaseClass;
using Domain.DTO.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolMinimalApi.Abstractions;

namespace SchoolMinimalApi.EndpointDefitnion
{
    public class ApiLoginEndpointDefitnion : IEndpointDefitnion
    {
        public void RegisterEndpoints(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            var userMap = app.MapGroup("/api/Login");

            userMap.MapPost("/SystemLogin", async (IMediator mediator, [FromBody] UserLoginDto userLogin, TokenService tokenService) =>
            {
                var allActiveUsersWithTheirActiveRole = new GetActiveUsersWithTheirActiveRole
                {
                    Password = userLogin.Password,
                    UserName = userLogin.UserName
                };

                var user = await mediator.Send(allActiveUsersWithTheirActiveRole);
                if (user == null) return Results.NotFound(new { message = "Invalid username or password" });

                var token = tokenService.GenerateToken(user);

                return Results.Ok(token);
            }).WithTags("SystemLogin");

            userMap.MapGet("/testpsw", (string psw) =>
            {
                var passwordKey = new PasswordKey();
                string key = passwordKey.key;
                string iv = passwordKey.iv;
                var password = CryptoHelper.EncryptAES(psw, key, iv);
                return Results.Ok(password);
            });
        }
    }
}
