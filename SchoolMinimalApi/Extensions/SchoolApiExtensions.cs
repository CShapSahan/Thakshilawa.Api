using Application.Abstractions.SchoolStudent;
using Application.Abstractions.Security;
using Application.Features.Security.Users.Commands;
using DataAccess.Repository.SchoolStudent;
using DataAccess.Repository.Security;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using MediatR;
using SchoolMinimalApi.Abstractions;
using Application.Abstractions.Error;
using DataAccess.Repository.Error;


namespace SchoolMinimalApi.Extensions
{
    public static class SchoolApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options =>
            {
                _ = options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection"), b => b.MigrationsAssembly("DataAccess"));

            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<DbContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IErrorLogRepository, ErrorLogRepository>();            
            builder.Services.AddMediatR(typeof(CreateUser));           
        }

        public static void RegisterEndpointDefitnion(this WebApplication app)
        {
            var endpointDefitnions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefitnion))
                && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefitnion>();
            foreach (var endpointDefitnion in endpointDefitnions) 
            {
                endpointDefitnion.RegisterEndpoints(app);
            }
        }

    }
}
