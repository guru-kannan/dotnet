namespace Catalog;

public class Prroduct
{
  private string _name;
  private decimal _price;
  public void SetName(string name) => _name = name;
  public string GetName() => _name;
  public void SetPrice(decimal price) => _price = price;
  public decimal GetPrice() => _price;
  public Prroduct()
  {
    _name = string.Empty;
    _price = 0.0m;
  }
  public Prroduct(string name, decimal price)
  {
    _name = name;
    _price = price;
  }
}