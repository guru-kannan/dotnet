namespace CustomerRepository;

using CustomerEntities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class CustomerRepository : ICustomerRepository
{

  public IEnumerable<Customer>? GetAllCustomers()
  {
    return JsonCustomerManager.LoadCustomers();
  }

  public Customer? GetCustomerById(int id)
  {
    var customers = GetAllCustomers();
    return customers?.FirstOrDefault(c => c.Id == id);
  }

  public void AddCustomer(Customer customer)
  {
    var customers = GetAllCustomers()?.ToList() ?? new List<Customer>();
    customers.Add(customer);
    JsonCustomerManager.SaveCustomers(customers);
  }
  
  public void UpdateCustomer(Customer customer)
  {
    var customers = GetAllCustomers()?.ToList() ?? new List<Customer>();
    var existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
    if (existingCustomer != null)
    {
      existingCustomer.FirstName = customer.FirstName;
      existingCustomer.LastName = customer.LastName;
      existingCustomer.Email = customer.Email;
      existingCustomer.Password = customer.Password;
      existingCustomer.Id = customer.Id;
      JsonCustomerManager.SaveCustomers(customers);
    }
  }
}
