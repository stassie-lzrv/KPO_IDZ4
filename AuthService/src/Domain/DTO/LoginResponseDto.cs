using Domain.Models;

namespace Domain.DTO;

public class LoginResponseDto
{
    public User User { get; set; }
    public string? Token { get; set; }
}