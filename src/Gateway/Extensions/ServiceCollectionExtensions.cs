using Accounts.UserService.Contracts;
using Gateway.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gateway.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        // serviceCollection.ConfigureSwaggerGen(opt =>
        // {
        //     opt.UseOneOfForPolymorphism();
        //     opt.SelectDiscriminatorNameUsing(_ => "$type");
        // });
        return serviceCollection;
    }

    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<UserServiceOptions>()
            .Bind(configuration.GetSection(UserServiceOptions.SectionName));
        services.AddGrpcClient<UserService.UserServiceClient>((sp, o) =>
        {
            IOptionsSnapshot<UserServiceOptions> options =
                sp.GetRequiredService<IOptionsSnapshot<UserServiceOptions>>();
            o.Address = new Uri(options.Value.Address);
        });

        return services;
    }
}