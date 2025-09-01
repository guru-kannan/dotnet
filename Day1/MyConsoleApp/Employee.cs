namespace HR;

public abstract class Employee
{
  public string Name { get; set; }
  public int Id { get; set; }

  public Employee()
  {
    Name = string.Empty;
    Id = 0;
  }
  public Employee(string name, int id)
  {
    Name = name;
    Id = id;
  }
  public abstract decimal CalculateSalary();
}