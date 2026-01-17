using Gateway.Application.Contracts;
using Gateway.Application.Services;
using Gateway.Extensions;
using Grpc.Controllers;
using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Gateway;

public static class Program
{
    public static async Task Main(string[] args)
    {
        WebApplication app = BuildApp();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseMiddleware<ExceptionFormattingMiddleware>();
        app.MapControllers();

        await app.RunAsync();
    }

    private static WebApplication BuildApp()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.Services.AddGrpcClients(builder.Configuration);

        builder.Services.AddScoped<ExceptionFormattingMiddleware>();

        builder.Services.AddSingleton<IAccountService, AccountService>();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(UserController).Assembly)
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        builder.Services.AddSwagger();

        return builder.Build();
    }
}