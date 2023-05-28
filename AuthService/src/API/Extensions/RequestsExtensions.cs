using API.Requests;
using Domain.DTO;

namespace API.Extensions;

public static class RequestsExtensions
{
    public static RegistrationRequestDto ToDto(this RegistrationRequest request)
    {
        return new RegistrationRequestDto
        {
            Email = request.Email,
            Password = request.Password,
            Login = request.Login,
            Role = request.Role
        };
    }
    
    public static LoginRequestDto ToDto(this LoginRequest request)
    {
        return new LoginRequestDto
        {
            Email = request.Email,
            Password = request.Password
        };
    }
}