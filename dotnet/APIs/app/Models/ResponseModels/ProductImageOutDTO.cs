namespace app.Models.ResponseModels;

public class ProductImageOutDTO
{
    public string ImageUrl { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
}