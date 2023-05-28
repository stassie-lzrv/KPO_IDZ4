using API.Requests.Dish;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]

public class DishController: ControllerBase
{
    private readonly IDishRepository _dishRepository;

    public DishController(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get(long id)
    {
        var dish = await _dishRepository.GetAsync(id);
        return Ok(dish);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateDishRequest request)
    {
        var id = await _dishRepository.CreateAsync(new DishEntity()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        });
        
        return Ok(id);
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(UpdateDishRequest request)
    {
        var rowsAffected = await _dishRepository.UpdateAsync(new DishEntity()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        });
        
        return Ok(rowsAffected);
    }
    
    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete(DeleteDishRequest request)
    {
        var rowsAffected = await _dishRepository.DeleteAsync(request.Id);
        return Ok(rowsAffected);
    }
    
}