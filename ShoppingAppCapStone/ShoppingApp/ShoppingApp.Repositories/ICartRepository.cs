using ShoppingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Repositories
{
    public interface ICartRepository
    {
        Task<List<ShoppingCart>> GetAllCartsAsync();
        Task<ShoppingCart?> GetCartByIdAsync(string id);
        Task CreateCartAsync(ShoppingCart cart);
        Task UpdateCartAsync(string id, ShoppingCart cart);
        Task DeleteCartAsync(string id);
    }
}
