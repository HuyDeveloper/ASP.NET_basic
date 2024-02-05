using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model;

public class ShoeDTO
{
    public int CartId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string Description { get; set; }
}