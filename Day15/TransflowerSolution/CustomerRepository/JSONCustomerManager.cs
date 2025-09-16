namespace CustomerRepository;

using CustomerEntities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class JsonCustomerManager
{
  // This class is intended to manage customer data stored in JSON format.
  // Implementation details would include methods for reading from and writing to JSON files,
  // as well as converting between JSON data and Customer objects.

  private static string GetJsonFilePath()
  {
    string filePath = @"C:\DotNet\dotnet\Day15\TransflowerSolution\Data\customers.json";
    return filePath;
  }

  public static IEnumerable<Customer>? LoadCustomers()
  {
    var json = File.ReadAllText(GetJsonFilePath());
    return JsonSerializer.Deserialize<IEnumerable<Customer>>(json);
  }
  public static void SaveCustomers(IEnumerable<Customer> customers)
  {
    var json = JsonSerializer.Serialize(customers);
    File.WriteAllText(GetJsonFilePath(), json);
  }
}