using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(string id);
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(string id, Order order);
    Task DeleteOrderAsync(string id);
}