using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public class RegistrationRequest
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; } = null!;
    [Required]
    public string? Password { get; set; } = null!;
    [Required]
    public string? Login { get; set; } = null!;
    [Required]
    public string? Role { get; set; } = null!;
}