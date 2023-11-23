using Microsoft.EntityFrameworkCore;

namespace DbFilter.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SecretTable> SecretTables;
}