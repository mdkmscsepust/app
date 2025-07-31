using app.Models;

namespace app.Repositories.ProductImageRepository;

public interface IProductImageRepository
{
    Task<bool> AddAsync(ProductImage productImage);
    Task<IEnumerable<ProductImage>> GetAllAsync();
    Task<ProductImage> GetByIdAsync(int id);
    Task<bool> DeleteAsync(ProductImage productImage);
}