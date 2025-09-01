using Catalog;
using HR;

int count = 45;
count++;

if (count > 50)
{
  Console.WriteLine("Count is greater than 50");
}
else
{
  Console.WriteLine("Count is less than or equal to 50");
}
Console.WriteLine($"Count: {count}");

var product = new Product("Laptop", 999.99m);
Console.WriteLine($"Product: {product.GetName()}, Price: {product.GetPrice()}");

SalesEmployee salesEmp = new SalesEmployee("Alice", 1, 50000m);
SalesManager salesMgr = new SalesManager("Bob", 2, 100000m, 15000m);

IProductRepository productRepo = new ProductRepository();
IProductService productService = new ProductService(productRepo);
List<Product> products = new List<Product>()
{
  new Product("Smartphone", 699.99m),
  new Product("Tablet", 399.99m),
  new Product("Smartwatch", 199.99m)
};

foreach (var prod in products)
{
  productService.AddProduct(prod);
}