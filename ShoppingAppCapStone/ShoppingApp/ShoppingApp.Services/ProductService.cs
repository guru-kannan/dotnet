using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<List<Product>> GetAllProductsAsync()
  {
    return await _productRepository.GetAllProductsAsync();
  }

  public async Task<Product?> GetProductByIdAsync(string id)
  {
    return await _productRepository.GetProductByIdAsync(id);
  }

  public async Task CreateProductAsync(Product product)
  {
    await _productRepository.CreateProductAsync(product);
  }

  public async Task UpdateProductAsync(string id, Product product)
  {
    await _productRepository.UpdateProductAsync(id, product);
  }

  public async Task DeleteProductAsync(string id)
  {
    await _productRepository.DeleteProductAsync(id);
  }
}