using API.Extensions;
using API.Requests;
using Domain.Extensions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        var dto = request.ToDto();
        
        await _authenticationService.RegisterAsync(dto);
        
        return Ok();
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var dto = request.ToDto();
        
        var responseDto = await _authenticationService.LoginAsync(dto);
        
        return Ok(responseDto);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("get-user/{id:long}")]
    public async Task<IActionResult> GetUser(long id, [FromServices] IUserRepository userRepository)
    {
        var entity = await userRepository.GetByIdAsync(id);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        return Ok(entity.ToModel());
    }
    
}