namespace TrainingPortal.Controllers;

using TrainingServices;
using TrainingEntities;
using Microsoft.AspNetCore.Mvc;
public class AuthController : Controller
{
  private readonly ITrainingService trainingService;

  public AuthController(ITrainingService trainingService)
  {
    this.trainingService = trainingService;
  }
[HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Login(string username, string password)
  {
    // For demonstration purposes, using hardcoded credentials.
    if (username == "admin@admin.com" && password == "password")
    {
      // this.Response.Redirect("/home/index");
      // In a real application, you would set up authentication cookies or tokens here.
      return RedirectToAction("Index", "Home");
    }
    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    return View();
  }

  public IActionResult Logout()
  {
    // In a real application, you would clear authentication cookies or tokens here.
    return RedirectToAction("Login");
  }
}