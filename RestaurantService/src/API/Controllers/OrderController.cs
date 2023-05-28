using API.Requests.Order;
using API.Extensions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var dto = request.ToDto();
        
        var id = await _orderService.CreateOrderAsync(dto);
        
        return Ok(id);
    }
    
    [HttpGet]
    [Route("get/{id:long}")]
    public async Task<IActionResult> GetOrder(long id)
    {
        var order = await _orderService.GetOrderAsync(id);
        
        return Ok(order);
    }
    
}