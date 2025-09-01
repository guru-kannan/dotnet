namespace Catalog;

public class Product
{
  private string _name;
  private decimal _price;
  public void SetName(string name) => _name = name;
  public string GetName() => _name;
  public void SetPrice(decimal price) => _price = price;
  public decimal GetPrice() => _price;
  public Product()
  {
    _name = string.Empty;
    _price = 0.0m;
  }
  public Product(string name, decimal price)
  {
    _name = name;
    _price = price;
  }
}