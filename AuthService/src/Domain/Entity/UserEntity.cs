using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Domain.Entity;

public class UserEntity
{
    public long Id { get; set; }
    public string? Email { get; set; }
    [Column("password_hash")]
    public string? PasswordHash { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public long? Xmin { get; set; }

    public static UserEntity FromModel(User model)
    {
        return new UserEntity
        {
            Email = model.Email,
            PasswordHash = model.PasswordHash,
            Username = model.Username,
            Role = model.Role
        };
    }
}