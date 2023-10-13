using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Products()
    {
        List<Product> temp = new List<Product>
        {
            new Product { ProductName = "apple" },
            new Product { ProductName = "banana" },
            new Product { ProductName = "potato" }
        };
        ProductsViewModel model = new ProductsViewModel
        {
            Products = temp
        };
        return View(model);
    }

    public IActionResult Apple()
    {
        return View();
    }
    
    public IActionResult Banana()
    {
        return View();
    }
    
    public IActionResult Potato()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}