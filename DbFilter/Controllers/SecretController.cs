using Microsoft.AspNetCore.Mvc;

namespace DbFilter.Controllers;

[Route("test")]
public class SecretController : Controller
{
    [HttpGet]
    public IActionResult Filter([FromQuery] int ownerId, int requestingId)
    {
        
    }
}