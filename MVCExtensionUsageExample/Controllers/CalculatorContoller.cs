using Microsoft.AspNetCore.Mvc;
using MVCExtensionUsageExample.Models;

namespace MVCExtensionUsageExample.Controllers;

public class CalculatorContoller : Controller
{
    [HttpGet]
    public IActionResult CalculatorViewModel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CalculatorViewModel(CalculatorViewModel calc)
    {
        return View(calc);
    }
}