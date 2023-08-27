using MediatR;
using SchoolMinimalApi.Extensions;
using Application.Features.Error.CommandHandlers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Builder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;
using Microsoft.VisualBasic;
using SchoolMinimalApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();


app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.RegisterEndpointDefitnion();

app.Run();

