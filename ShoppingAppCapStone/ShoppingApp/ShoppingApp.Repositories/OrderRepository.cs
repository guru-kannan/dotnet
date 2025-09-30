using MongoDB.Driver;
using ShoppingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _orderCollection;

    public OrderRepository(IMongoDatabase database)
    {
        _orderCollection = database.GetCollection<Order>("orders");
    }

    public async Task<List<Order>> GetAllOrdersAsync() =>
        await _orderCollection.Find(_ => true).ToListAsync();

    public async Task<Order?> GetOrderByIdAsync(string id)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        return await _orderCollection.Find(o => o.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateOrderAsync(Order order) =>
        await _orderCollection.InsertOneAsync(order);

    public async Task UpdateOrderAsync(string id, Order order)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        await _orderCollection.ReplaceOneAsync(o => o.Id == id, order);
    }

    public async Task DeleteOrderAsync(string id)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        await _orderCollection.DeleteOneAsync(o => o.Id == id);
    }
}