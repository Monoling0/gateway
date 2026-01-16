using Gateway.Extensions;
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

        builder.Services.AddControllers()
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        builder.Services.AddSwagger();

        return builder.Build();
    }
}