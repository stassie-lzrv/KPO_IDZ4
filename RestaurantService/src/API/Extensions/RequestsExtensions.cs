using API.Requests.Order;
using Domain.DTO;

namespace API.Extensions;

public static class RequestsExtensions
{
    public static CreateOrderRequestDto ToDto(this CreateOrderRequest request)
    {
        return new CreateOrderRequestDto
        {
            UserId = request.UserId,
            SpecialIRequests = request.SpecialIRequests,
            Dishes = request.DishQuantities.Select(pair =>
            {
                return (pair.Key, pair.Value);
            }).ToList()
        };
    }
}