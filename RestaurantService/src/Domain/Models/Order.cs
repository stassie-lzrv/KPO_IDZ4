namespace Domain.Models;

public class Order
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Status { get; set; }
    
    public string SpecialRequests { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public List<Dish> Dishes { get; set; }
}