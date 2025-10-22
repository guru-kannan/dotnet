using MongoDB.Driver;
using ShoppingApp.Entities;
using ShoppingApp.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductRepository(IMongoDatabase database)
    {
        _productCollection = database.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAllProductsAsync() =>
        await _productCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetProductByIdAsync(string id)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        return await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateProductAsync(Product product) =>
        await _productCollection.InsertOneAsync(product);

    public async Task UpdateProductAsync(string id, Product product)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        await _productCollection.ReplaceOneAsync(p => p.Id == id, product);
    }

    public async Task DeleteProductAsync(string id)
    {
        var objectId = MongoDB.Bson.ObjectId.Parse(id);
        await _productCollection.DeleteOneAsync(p => p.Id == id);
    }
}