using ShoppingApp.Entities;

namespace ShoppingApp.Repositories;

public interface IProductRepository
{
  Task<List<Product>> GetAllProductsAsync();
  Task<Product?> GetProductByIdAsync(string id);
  Task CreateProductAsync(Product product);
  Task UpdateProductAsync(string id, Product product);
  Task DeleteProductAsync(string id);
}