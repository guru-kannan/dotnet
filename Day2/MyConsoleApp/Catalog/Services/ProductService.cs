namespace Catalog;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }
  public void AddProduct(Product product)
  {
    _productRepository.AddProduct(product);
  }
  public Product GetProduct(string name)
  {
    return _productRepository.GetProduct(name);
  }
  public IEnumerable<Product> GetAllProducts()
  {
    return _productRepository.GetAllProducts();
  }
  public void UpdateProduct(Product product)
  {
    _productRepository.UpdateProduct(product);
  }

  public void DeleteProduct(string name)
  {
    _productRepository.DeleteProduct(name);
  }
}