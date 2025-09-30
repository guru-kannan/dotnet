using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entities;
using ShoppingApp.Services;

namespace ShoppingApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShoppingCart>>> GetAllCarts()
    {
        var carts = await _cartService.GetAllCartsAsync();
        return Ok(carts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
    {
        var cart = await _cartService.GetCartByIdAsync(id);
        if (cart == null)
        {
            return NotFound();
        }
        return Ok(cart);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCart([FromBody] ShoppingCart cart)
    {
        await _cartService.CreateCartAsync(cart);
        return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCart(string id, [FromBody] ShoppingCart cart)
    {
        var existingCart = await _cartService.GetCartByIdAsync(id);
        if (existingCart == null)
        {
            return NotFound();
        }
        await _cartService.UpdateCartAsync(id, cart);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCart(string id)
    {
        var existingCart = await _cartService.GetCartByIdAsync(id);
        if (existingCart == null)
        {
            return NotFound();
        }
        await _cartService.DeleteCartAsync(id);
        return NoContent();
    }
}