namespace CustomerRepository;
using CustomerEntities;
using System.Collections.Generic;

public interface ICustomerRepository
{
  IEnumerable<Customer>? GetAllCustomers();
  Customer? GetCustomerById(int id);
  void AddCustomer(Customer customer);
  void UpdateCustomer(Customer customer);
  
}