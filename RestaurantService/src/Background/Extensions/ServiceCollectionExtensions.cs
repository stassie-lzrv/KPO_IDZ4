using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Background.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<OrderHostedService>();

        return services;
    }
}