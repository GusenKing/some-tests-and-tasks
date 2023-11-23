using DbFilter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("TestDb"));

using var context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
    .UseInMemoryDatabase("TestDb")
    .Options);
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

context.AddRange(
    new SecretTable { Id = 1, IdOwner = 100, SomeSecretKey = "this is secret key", AllowedUsers = "101 102 123"},
    new SecretTable { Id = 2, IdOwner = 123, SomeSecretKey = "i love coffee", AllowedUsers = "101 103 524"});
context.SaveChanges();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();