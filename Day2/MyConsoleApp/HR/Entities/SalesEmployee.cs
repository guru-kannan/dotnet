namespace HR;

public class SalesEmployee : Employee
{
  private decimal salesTarget;
  public void SetSalesTarget(decimal target) => salesTarget = target;
  public decimal GetSalesTarget() => salesTarget;
  public SalesEmployee() : base()
  {
    salesTarget = 0.0m;
  }
  public SalesEmployee(string name, int id, decimal target) : base(name, id)
  {
    salesTarget = target;
  }
  public override decimal CalculateSalary()
  {
    return salesTarget * 0.1m;
  }
}