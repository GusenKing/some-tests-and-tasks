namespace WebApplication1.Models;

public class ProductsViewModel
{
    public List<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ImageSource { get; set; }
}