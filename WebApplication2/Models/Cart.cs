using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model;
[Table("cart")]
public class Cart
{
    /*public Cart(int id, List<Shoe> shoes)
    {
        this.id = id;
        Shoes = shoes;
    }*/
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key,Required]
    public int id { get; set; }

    public List<Shoe> Shoes { get; set; } = new List<Shoe>();
}