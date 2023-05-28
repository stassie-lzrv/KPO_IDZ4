using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order;

public class GetOrderRequest
{
    [Required]
    public long Id { get; set; }
}