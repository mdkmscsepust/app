using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class ProductImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}