
namespace TransflowerPortal.Controllers;

using CatalogEntities;
using CatalogServices;
using Microsoft.AspNetCore.Mvc;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    // Dependency Injection via constructor
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: /Products
    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();
        //return ViewResults as JSON for testing
        return View(products);


    }

    // GET: /Products/Details/5
    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        ViewData["theProduct"] = product;

        return View();
    }

    // GET: /Products/Create
    public IActionResult Create()
    {

        TempData["Message"] = "Create New Product";
        
        return View();
    }

    // POST: /Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: /Products/Edit/5
    public IActionResult Edit(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: /Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: /Products/Delete/5
    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: /Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }
}

