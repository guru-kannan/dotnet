
namespace TransflowerPortal.Controllers;

using CatalogEntities;
using CatalogServices;
using Microsoft.AspNetCore.Mvc;
using CustomerEntities;
using CustomerRepository;
using CustomerServices;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.

public class AuthController : Controller
{


    //Dependency Injection for ICustomerService, CustomerService
    private readonly ICustomerService _customerService;
    public AuthController()
    {
        _customerService = new CustomerService(new CustomerRepository());
    }


    [HttpGet]   //attribute , Decorator, Annotation, Metadata
                //Action Filter
    public IActionResult Login()
    {

        return View();
    }


    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var customers = _customerService.GetAllCustomers()?.ToList() ?? new List<Customer>();
        var customer = customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        if (customer != null)
        {
            this.Response.Redirect("/home/index");
        }
        ViewData["Error"] = "Invalid Email or Password";
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(string firstname, string lastname, string email, string password)
    {
        Customer customer = new Customer();
        customer.FirstName = firstname;
        customer.LastName = lastname;
        customer.Email = email;
        customer.Password = password;
        var customers = new CustomerService(new CustomerRepository()).GetAllCustomers()?.ToList() ?? new List<Customer>();
        customer.Id = customers.Count + 1;
        customers.Add(customer);
        JsonCustomerManager.SaveCustomers(customers);
        return Redirect("/Auth/Login");
    }

}