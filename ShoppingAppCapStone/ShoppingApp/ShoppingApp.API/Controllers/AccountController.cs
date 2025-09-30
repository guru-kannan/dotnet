using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ShoppingApp.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class AccountController : Controller
{
  [HttpGet]
  public IActionResult Login() => View();

  [HttpPost]
  public IActionResult Login(LoginViewModel model)
  {
    if (model.Username == "admin" && model.Password == "password")
    {
      var claims = new[] { new Claim(ClaimTypes.Name, model.Username) };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
          issuer: "yourissuer",
          audience: "youraudience",
          claims: claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds
      );
      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      Response.Cookies.Append("jwt_token", jwt);
      return RedirectToAction("Index", "Home");
    }
    ViewData["Error"] = "Invalid login.";
    return View();
  }

  public IActionResult Logout()
  {
    Response.Cookies.Delete("jwt_token");
    return RedirectToAction("Login");
  }
}
