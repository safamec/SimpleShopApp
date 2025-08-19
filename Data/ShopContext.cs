using Microsoft.EntityFrameworkCore;
using SimpleShopApp.Models;

namespace SimpleShopApp.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}