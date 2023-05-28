using Domain.DTO;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDishRepository _dishRepository;

    private static Object _lock;

    static OrderService()
    {
        _lock = new();
    }
     
    public OrderService(IOrderRepository orderRepository, IDishRepository dishRepository)
    {
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
    }
    
    public async Task<long> CreateOrderAsync(CreateOrderRequestDto dto)
    {
        var dishIds = dto.Dishes.Select(d => d.Item1).ToArray();
        
        var dishes = await _dishRepository.GetManyByIdAsync(dishIds);
    
        foreach (var (id, quantity) in dto.Dishes)
        {
            var dish = dishes.FirstOrDefault(d => d.Id == id);
            if (dish == null)
            {
                throw new DishNotFoundException($"Dish with id {id} not found");
            }
            if (dish.Quantity < quantity)
            {
                throw new NotEnoughQuantityException($"Dish with id {id} has only {dish.Quantity} left");
            }
        }
    
        var order = new OrderEntity()
        {
            UserId = dto.UserId,
            SpecialRequests = dto.SpecialIRequests,
            Status = "waiting",
            Dishes = dto.Dishes.Select(d => (new DishEntity()
            {
                Id = d.Item1,
                Price = dishes.First(dish => dish.Id == d.Item1).Price,
                Quantity = d.Item2
            })).ToList()
        };
    
        var orderId = await _orderRepository.CreateOrderAsync(order);
        
        await _dishRepository.DecreaseQuantityAsync(dto.Dishes);

        return orderId;
    }

    public async Task<Order> GetOrderAsync(long id)
    {
        var entity = await _orderRepository.GetOrderAsync(id);

        var order = new Order()
        {
            Id = entity.Id,
            UserId = entity.UserId,
            SpecialRequests = entity.SpecialRequests,
            Status = entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Dishes = entity.Dishes.Select(d => new Dish()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                Quantity = d.Quantity
            }).ToList()
        };

        return order;
    }
}