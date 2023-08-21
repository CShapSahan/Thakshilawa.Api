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
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddScoped<TokenService>();
            var secretKey = Application.Services.Setting.GenerateSecretByte();

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer
            (options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("manager", policy => policy.RequireRole("manager"));
                options.AddPolicy("admin", policy => policy.RequireRole("admin"));
                options.AddPolicy("SystemAdmin", policy => policy.RequireRole("SystemAdmin"));
            });

            builder.Services.AddSwaggerGen(s =>            {
              

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
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
