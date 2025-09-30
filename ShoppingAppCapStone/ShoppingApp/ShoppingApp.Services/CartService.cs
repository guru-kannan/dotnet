using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<List<ShoppingCart>> GetAllCartsAsync()
    {
        return await _cartRepository.GetAllCartsAsync();
    }

    public async Task<ShoppingCart?> GetCartByIdAsync(string id)
    {
        return await _cartRepository.GetCartByIdAsync(id);
    }

    public async Task CreateCartAsync(ShoppingCart shoppingCart)
    {
        await _cartRepository.CreateCartAsync(shoppingCart);
    }

    public async Task UpdateCartAsync(string id, ShoppingCart shoppingCart)
    {
        await _cartRepository.UpdateCartAsync(id, shoppingCart);
    }

    public async Task DeleteCartAsync(string id)
    {
        await _cartRepository.DeleteCartAsync(id);
    }
}