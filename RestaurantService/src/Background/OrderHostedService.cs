using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Background;

public class OrderHostedService: IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OrderHostedService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    private async Task DoWork()
    {
        using var scope = _scopeFactory.CreateScope();
        var orderService = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

        while (true)
        {
            var orderEntities = (await orderService.GetPendingOrdersAsync(10)).ToList();
            
            foreach (var order in orderEntities)
            {
                await orderService.SetStatusAsync(order.Id, "processing");
            }

            await Task.Delay(10000);
            
            foreach (var order in orderEntities)
            {
                await orderService.SetStatusAsync(order.Id, "done");
            }
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(() => DoWork(), cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}