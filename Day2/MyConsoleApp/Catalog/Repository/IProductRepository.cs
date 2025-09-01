namespace Catalog;

public interface IProductRepository
{
  void AddProduct(Product product);
  Product GetProduct(string name);
  IEnumerable<Product> GetAllProducts();
  void UpdateProduct(Product product);
  void DeleteProduct(string name);
}