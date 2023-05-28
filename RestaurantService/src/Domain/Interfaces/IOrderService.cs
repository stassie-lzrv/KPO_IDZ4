using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces;

public interface IOrderService
{
    Task<long> CreateOrderAsync(CreateOrderRequestDto dto);
    Task<Order> GetOrderAsync(long id);
}