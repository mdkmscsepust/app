using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;

namespace App.Application.Interfaces;

public interface IProductImageService
{
    Task<bool> AddAsync(ProductImageInDTO request);
    Task<IEnumerable<ProductImageOutDTO>> GetAllAsync();
    Task<ProductImageOutDTO> GetByIdAsync(int id);
    void DeleteAsync(string filePath);
}