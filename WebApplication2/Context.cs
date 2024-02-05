using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cart>()
            .HasMany(a => a.Shoes)
            .WithOne(b =>b.Cart)
            .HasForeignKey(c => c.CartId);*/
        //.IsRequired(false) có thể làm fk nullable
        // Có thể dùng để map lại fk nêu đặt tên không giống quy chuẩn
        var shoeList = new Shoe[]
        {
            new Shoe { id = 1, brand = "Nike", name = "Nike Air Force 1", price = 100, description = "Nike Air Force 1", CartId = 1},
            new Shoe {id = 2,brand = "Nike", name = "Nike Air Force 2", price = 200, description = "Nike Air Force 2" , CartId = 1},
            new Shoe {id = 3,brand = "Nike", name = "Nike Air Force 3", price = 300, description = "Nike Air Force 3" , CartId = 2},
            new Shoe {id = 4,brand = "Nike", name = "Nike Air Force 4", price = 400, description = "Nike Air Force 4", CartId = 2},
        };
        modelBuilder.Entity<Shoe>().HasData(shoeList);
        
        var cartList = new Cart[]
        {
            new Cart { id = 1},
            new Cart { id = 2},
        };
        modelBuilder.Entity<Cart>().HasData(cartList);
        
    }

    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Cart> Carts { get; set; }
}