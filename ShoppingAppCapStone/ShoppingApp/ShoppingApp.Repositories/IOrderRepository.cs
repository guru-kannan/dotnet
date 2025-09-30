using ShoppingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(string id);
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(string id, Order order);
    Task DeleteOrderAsync(string id);
}