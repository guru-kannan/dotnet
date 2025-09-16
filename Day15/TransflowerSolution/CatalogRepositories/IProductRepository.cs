namespace CatalogRepositories;

using CatalogEntities;
using System.Collections.Generic;   
public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}
