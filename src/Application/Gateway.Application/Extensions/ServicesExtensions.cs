using Gateway.Application.Contracts;
using Gateway.Application.Contracts.Courses;
using Gateway.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Application.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddAllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAccountService, AccountService>();
        serviceCollection.AddScoped<ICourseService, CourseService>();

        return serviceCollection;
    }
}