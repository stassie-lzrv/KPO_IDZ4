using Domain.Interfaces;
using Infrastructure.Repositories.Dish;
using Infrastructure.Repositories.Order;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}