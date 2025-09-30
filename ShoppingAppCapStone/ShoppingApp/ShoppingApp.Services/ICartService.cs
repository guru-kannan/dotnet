using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public interface ICartService
{
    Task<List<ShoppingCart>> GetAllCartsAsync();
    Task<ShoppingCart?> GetCartByIdAsync(string id);
    Task CreateCartAsync(ShoppingCart shoppingCart);
    Task UpdateCartAsync(string id, ShoppingCart shoppingCart);
    Task DeleteCartAsync(string id);
}