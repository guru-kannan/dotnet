using MongoDB.Driver;
using ShoppingApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<ShoppingCart> _cartCollection;

        public CartRepository(IMongoDatabase database)
        {
            _cartCollection = database.GetCollection<ShoppingCart>("ShoppingCarts");
        }

        public async Task<List<ShoppingCart>> GetAllCartsAsync() =>
            await _cartCollection.Find(_ => true).ToListAsync();

        public async Task<ShoppingCart?> GetCartByIdAsync(string id)
        {
            var objectId = MongoDB.Bson.ObjectId.Parse(id);
            return await _cartCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateCartAsync(ShoppingCart cart) =>
            await _cartCollection.InsertOneAsync(cart);

        public async Task UpdateCartAsync(string id, ShoppingCart cart)
        {
            var objectId = MongoDB.Bson.ObjectId.Parse(id);
            await _cartCollection.ReplaceOneAsync(c => c.Id == id, cart);
        }

        public async Task DeleteCartAsync(string id)
        {
            var objectId = MongoDB.Bson.ObjectId.Parse(id);
            await _cartCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
