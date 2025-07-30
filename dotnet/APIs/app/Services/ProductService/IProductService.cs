using app.Models;

namespace app.Services.ProductService;

public interface IProductService
{
    Task<bool> AddAsync(Product product);

    Task<bool> UpdateAsync(Product product);

    Task<Product> GetByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllAsync();
}