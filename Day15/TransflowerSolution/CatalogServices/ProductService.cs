
namespace CatalogServices;

using CatalogEntities;
using System.Collections.Generic;
using CatalogRepositories;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;


    // Dependency Injection via constructor
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        


        // Do something with userId
        //file IO operations
        return _productRepository.GetAllProducts();
    }

    public Product? GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.DeleteProduct(id);
    }
}