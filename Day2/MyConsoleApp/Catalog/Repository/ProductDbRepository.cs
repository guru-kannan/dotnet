namespace Catalog;

public class ProductDbRepository : IProductRepository
{
  public void AddProduct(Product product)
  {

  }
  public Product GetProduct(string name)
  {
    return new Product();
  }
  public IEnumerable<Product> GetAllProducts()
  {
    return new List<Product>();
  }
  public void UpdateProduct(Product product)
  {
  }
  public void DeleteProduct(string name)
  {
  }
}