using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public interface IProductService
{
  Task<List<Product>> GetAllProductsAsync();
  Task<Product?> GetProductByIdAsync(string id);
  Task CreateProductAsync(Product product);
  Task UpdateProductAsync(string id, Product product);
  Task DeleteProductAsync(string id);
}