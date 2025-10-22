using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ShoppingApp.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ShoppingApp.Services;
using ShoppingApp.Entities;

public class AccountController : Controller
{
  private readonly IUserService _userService;
  private readonly IConfiguration _configuration;
  private readonly ILogger<AccountController> _logger;

  public AccountController(IUserService userService, IConfiguration configuration, ILogger<AccountController> logger)
  {
    _userService = userService;
    _configuration = configuration;
    _logger = logger;
  }
  [HttpGet]
  public IActionResult Login() => View();

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (!ModelState.IsValid)
      return View(model);

    var isValid = await _userService.ValidateUserCredentialsAsync(model.Username, model.Password);
    if (isValid)
    {
      var jwtSettings = _configuration.GetSection("Jwt");
      var claims = new[] { new Claim(ClaimTypes.Name, model.Username) };

      var keyString = jwtSettings["Key"];
      if (string.IsNullOrEmpty(keyString))
      {
        _logger.LogError("JWT key is not configured in 'Jwt:Key'.");
        ModelState.AddModelError(string.Empty, "Authentication configuration error.");
        return View(model);
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
          issuer: jwtSettings["Issuer"],
          audience: jwtSettings["Audience"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds
      );
      _logger.LogInformation("User {Username} logged in at {Time} with {token}", model.Username, DateTime.UtcNow, token);
      _logger.LogInformation("JWT Token generated for user {Issuer} and audience {Audience}", jwtSettings["Issuer"], jwtSettings["Audience"]);
      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      Response.Cookies.Append("jwt_token", jwt);
      return RedirectToAction("Index", "Products");
    }
    ViewData["Error"] = "Invalid login.";
    return View(model);
  }

  [HttpGet]
  public IActionResult Register() => View();

  [HttpPost]
  public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (!ModelState.IsValid)
        return View(model);

    // Call service layer to create new user
    await _userService.CreateUserAsync(new User {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = model.Password
        });

    return RedirectToAction("Login");
}

  public IActionResult Logout()
  {
    Response.Cookies.Delete("jwt_token");
    return RedirectToAction("Login");
  }
}
