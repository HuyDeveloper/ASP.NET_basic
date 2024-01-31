using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}