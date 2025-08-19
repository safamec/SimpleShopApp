using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShopApp.Data;
using SimpleShopApp.Models;

namespace SimpleShopApp.Controllers
{
   public class ProductController : Controller
{
    private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
    
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
    }
}

}