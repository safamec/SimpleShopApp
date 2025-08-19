using Microsoft.EntityFrameworkCore;
using SimpleShopApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC
builder.Services.AddControllersWithViews();

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Seed database ...
// (الكود الموجود عندك للمنتجات هنا)

app.UseStaticFiles();
app.UseSession(); // <-- هنا قبل UseRouting
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
