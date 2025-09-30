using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Entities;
using ShoppingApp.Services;

namespace ShoppingApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] Product product)
    {
        await _productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(string id, [FromBody] Product product)
    {
        var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        await _productService.UpdateProductAsync(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}