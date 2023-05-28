using Domain.Entity;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<OrderEntity> GetOrderAsync(long id);
    Task<IEnumerable<OrderEntity>> GetPendingOrdersAsync(long limit);
    Task<long> SetStatusAsync(long id, string status);
    Task<long> CreateOrderAsync(OrderEntity order);
}