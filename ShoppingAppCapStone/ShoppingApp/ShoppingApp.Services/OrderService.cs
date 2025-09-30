using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(string id)
    {
        return await _orderRepository.GetOrderByIdAsync(id);
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _orderRepository.CreateOrderAsync(order);
    }

    public async Task UpdateOrderAsync(string id, Order order)
    {
        await _orderRepository.UpdateOrderAsync(id, order);
    }

    public async Task DeleteOrderAsync(string id)
    {
        await _orderRepository.DeleteOrderAsync(id);
    }
}