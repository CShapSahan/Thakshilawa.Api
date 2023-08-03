using MediatR;
using SchoolMinimalApi.Extensions;
using Application.Features.Error.CommandHandlers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Builder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
  
    var createErrorLog = new CreateErrorLog
    {
        Message = exception.Message,
        ApiPath = context.Request.Path,
    };
    if (exception.InnerException != null)
    {
        createErrorLog.InnerException = exception.InnerException.Message;
    }
    else
    {
        createErrorLog.InnerException = "";
    }   
    context.Response.Redirect("/api/errorLog/exception/" +  createErrorLog.Message +","+ createErrorLog.ApiPath.Replace("/","-") + "," + createErrorLog.InnerException);
   
})) ;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.RegisterEndpointDefitnion();

app.Run();

