using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController: ControllerBase
{
    private readonly IDishRepository _dishRepository;

    public MenuController(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get()
    {
        var dish = await _dishRepository.GetAllAsync();
        return Ok(dish);
    }
}