using app.Models.RequestModels;
using app.Models.ResponseModels;

namespace app.Services.ProductImageService;

public interface IProductImageService
{
    Task<bool> AddAsync(ProductImageInDTO request);
    Task<IEnumerable<ProductImageOutDTO>> GetAllAsync();
    Task<ProductImageOutDTO> GetByIdAsync(int id);
    void DeleteAsync(string filePath);
}