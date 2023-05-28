using Domain.DTO;

namespace Domain.Interfaces;

public interface IAuthenticationService
{
    Task<long> RegisterAsync(RegistrationRequestDto dto);
    Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
}