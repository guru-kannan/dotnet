namespace Catalog;

public class ProductRepository : IProductRepository
{
  private List<Product> _products = new List<Product>();
  public void AddProduct(Product product)
  {
    _products.Add(product);
  }
  public Product GetProduct(string name)
  {
    return _products.FirstOrDefault(p => p.GetName() == name) ?? new Product();
  }
  public IEnumerable<Product> GetAllProducts()
  {
    return _products;
  }
  public void UpdateProduct(Product product)
  {
    var existingProduct = _products.FirstOrDefault(p => p.GetName() == product.GetName());
    existingProduct?.SetPrice(product.GetPrice());
  }
  public void DeleteProduct(string name)
  {
    var product = _products.FirstOrDefault(p => p.GetName() == name);
    if (product != null)
    {
      _products.Remove(product);
    }
  }
}