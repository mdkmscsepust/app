namespace app.Models.RequestModels;

public class ProductImageInDTO
{
    public IFormFile? ImageFile { get; set; }
    public int ProductId { get; set; }
}