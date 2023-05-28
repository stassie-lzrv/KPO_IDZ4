using System.ComponentModel.DataAnnotations;

namespace API.Requests.Dish;

public class DeleteDishRequest
{
    [Required] public long Id { get; set; }
}