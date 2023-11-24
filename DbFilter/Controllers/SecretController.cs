using DbFilter.ContextExtensions;
using DbFilter.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFilter.Controllers;

[Route("test")]
public class SecretController : Controller
{
    [HttpGet]
    public IActionResult Filter([FromQuery] int ownerId, int requestingId)
    {
        using (var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                   .UseInMemoryDatabase("TestDb").Options))
        {
            var requestedRow = db.CheckPermission(ownerId, requestingId).ToList();

            if (requestedRow.Count == 0)
                return Unauthorized();

            return Ok(requestedRow.First().SomeSecretKey);
        }       
    }
}