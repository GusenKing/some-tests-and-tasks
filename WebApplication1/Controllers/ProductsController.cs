using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ProductsController : Controller
{
    private static List<Product> productsList = new List<Product>{
        new Product { Id = 0, ProductName = "Apple", ImageSource = "https://t3.ftcdn.net/jpg/01/76/97/96/360_F_176979696_hqfioFYq7pX13dmiu9ENrpsHZy1yM3Dt.jpg" },
        new Product { Id = 1, ProductName = "Banana", ImageSource = "https://images.unsplash.com/photo-1587132137056-bfbf0166836e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YmFuYW5hfGVufDB8fDB8fHww&w=1000&q=80" },
        new Product { Id = 2, ProductName = "Potato", ImageSource = "https://t3.ftcdn.net/jpg/02/43/91/16/360_F_243911639_jAhwMXsfOWQj609an2ItGYqJDfXQyz6Y.jpg" },
    };
    
    private static ProductsViewModel productsModel = new ProductsViewModel
    {
        Products = productsList
    };

    public IActionResult ProductsList()
    {
           
        return View(productsModel);
    }
    public IActionResult Details(int id)
    {
        var product = new Product
        {
            Id = id,
            ProductName = productsModel.Products[id].ProductName,
            ImageSource = productsModel.Products[id].ImageSource
        };

        return View(product);
    }
}