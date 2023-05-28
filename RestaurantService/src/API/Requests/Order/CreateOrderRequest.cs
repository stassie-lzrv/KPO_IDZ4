using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order;

public class CreateOrderRequest
{
    [Required]
    public long UserId { get; set; }
    public string? SpecialIRequests { get; set; }
    [Required]
    public Dictionary<long, int> DishQuantities { get; set; }
}