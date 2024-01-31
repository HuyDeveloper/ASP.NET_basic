using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("product")]
public class Product
{
    public Product(string name, string brand, decimal price)
    {
        this.name = name;
        this.brand = brand;
        this.price = price;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key,Required]
    public int id { get; set; }
    
    public string name { get; set; }
    public string brand { get; set; }
    public decimal price { get; set; }
}