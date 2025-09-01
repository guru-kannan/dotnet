namespace HR;

public abstract class Employee
{
  private string _name;
  private int _id;
  protected int empId;

  public void SetName(string name) => _name = name;
  public string GetName() => _name;
  public void SetId(int id)
  {
    _id = id;
    empId = id;
  }
  public int GetId() => _id;

  public Employee()
  {
    _name = string.Empty;
    _id = 0;
    empId = 0;
  }
  public Employee(string name, int id)
  {
    _name = name;
    _id = id;
    empId = id;
  }
  public abstract decimal CalculateSalary();
}