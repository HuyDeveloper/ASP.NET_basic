using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("shoe")]
public class Shoe
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key,Required]
    public int id { get; set; }
    
    public string name { get; set; }
    public string brand { get; set; }
    public decimal price { get; set; }
    public string description { get; set; }
    
    public int CartId { get; set; }
    public Cart Cart { get; set; }
}