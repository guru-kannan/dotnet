namespace HR;

public sealed class SalesManager : SalesEmployee
{
  private decimal bonus;

  public void SetBonus(decimal bonus) => this.bonus = bonus;
  public decimal GetBonus() => bonus;

  public SalesManager() : base()
  {
    bonus = 0.0m;
  }
  public SalesManager(string name, int id, decimal target, decimal bonus) : base(name, id, target)
  {
    this.bonus = bonus;
  }
  public decimal ComputeTotalCompensation()
  {
    return CalculateSalary() + bonus;
  }
}