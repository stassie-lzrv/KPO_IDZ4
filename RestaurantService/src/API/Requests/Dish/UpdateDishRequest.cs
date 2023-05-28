using System.ComponentModel.DataAnnotations;

namespace API.Requests.Dish;

public class UpdateDishRequest
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Quantity { get; set; }
}