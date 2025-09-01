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

var product = new Prroduct("Laptop", 999.99m);
Console.WriteLine($"Product: {product.GetName()}, Price: {product.GetPrice()}");  

SalesEmployee salesEmp = new SalesEmployee("Alice", 1, 50000m);
Console.WriteLine($"Sales Employee: {salesEmp.Name}, ID: {salesEmp.Id}, Sales Target: {salesEmp.GetSalesTarget()}, Salary: {salesEmp.CalculateSalary()}");
SalesManager salesMgr = new SalesManager("Bob", 2, 100000m, 15000m);
Console.WriteLine($"Sales Manager: {salesMgr.Name}, ID: {salesMgr.Id}, Sales Target: {salesMgr.GetSalesTarget()}, Bonus: {salesMgr.GetBonus()}, Total Compensation: {salesMgr.ComputeTotalCompensation()}");