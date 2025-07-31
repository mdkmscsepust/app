namespace app.Models.RequestModels;

public class ProductInDTO
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}