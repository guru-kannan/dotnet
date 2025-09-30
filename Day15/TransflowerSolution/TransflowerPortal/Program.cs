using CatalogRepositories;
using CatalogServices;
using CustomerRepository;
using CustomerServices;
using Microsoft.AspNetCore.Authentication.Cookies; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//CRM Repository and Service Registration


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository.CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerServices.CustomerService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/login"; // Set the login path
        options.LogoutPath = "/auth/logout"; // Set the logout path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set cookie expiration time
    });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Transflower.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Set the cookie to be accessible only via HTTP
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(5)));
    options.AddPolicy("CasheFor30Seconds", builder => builder.Expire(TimeSpan.FromSeconds(30)));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseOutputCache();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
