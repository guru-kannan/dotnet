using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entities;
using ShoppingApp.Services;

namespace ShoppingApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(string id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] Order order)
    {
        await _orderService.CreateOrderAsync(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(string id, [FromBody] Order order)
    {
        var existingOrder = await _orderService.GetOrderByIdAsync(id);
        if (existingOrder == null)
        {
            return NotFound();
        }
        await _orderService.UpdateOrderAsync(id, order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(string id)
    {
        var existingOrder = await _orderService.GetOrderByIdAsync(id);
        if (existingOrder == null)
        {
            return NotFound();
        }
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}