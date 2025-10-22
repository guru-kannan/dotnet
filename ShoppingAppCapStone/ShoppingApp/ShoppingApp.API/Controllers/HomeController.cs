using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.API.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Welcome()
    {
        return View();
    }
}
