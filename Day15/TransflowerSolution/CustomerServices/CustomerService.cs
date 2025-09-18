namespace CustomerServices;

using CustomerEntities;
using CustomerRepository;
using System.Collections.Generic;

public class CustomerService : ICustomerService
{
  private readonly ICustomerRepository _customerRepository;

  // Dependency Injection for ICustomerRepository, CustomerRepository
  public CustomerService(ICustomerRepository customerRepository)
  {
    _customerRepository = customerRepository;
  }

  public IEnumerable<Customer>? GetAllCustomers()
  {
    return _customerRepository.GetAllCustomers();
  }

  public Customer? GetCustomerById(int id)
  {
    return _customerRepository.GetCustomerById(id);
  }

  public void AddCustomer(Customer customer)
  {
    _customerRepository.AddCustomer(customer);
  }

  public void UpdateCustomer(Customer customer)
  {
    _customerRepository.UpdateCustomer(customer);
  }

  public Customer? ValidateCustomer(string email, string password)
  {
    return _customerRepository.GetAllCustomers().FirstOrDefault(c => c.Email == email && c.Password == password);
  }
}
