using Microsoft.AspNetCore.Mvc;
using TransflowerPortal.Models;
using System.Reflection.Metadata.Ecma335;

namespace StateManagementApp.Controllers;

public class StateManagementController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult SetQueryString([FromQuery] string username, [FromQuery] string lastname)
  {
    ViewBag.Username = username;
    ViewBag.Lastname = lastname;
    return View();
  }
  public IActionResult SetCookies()
  {
    // Set cookies
    Response.Cookies.Append("Username", "JohnDoe");
    Response.Cookies.Append("Lastname", "Smith");
    return View();
  }

  public IActionResult GetCookies()
  {
    // Retrieve cookies
    var username = Request.Cookies["Username"];
    var lastname = Request.Cookies["Lastname"];
    ViewBag.Username = username;
    ViewBag.Lastname = lastname;
    return View();
  }
}