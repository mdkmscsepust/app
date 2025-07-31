using app.Models;
using app.Models.RequestModels;
using app.Models.ResponseModels;

namespace app.Services.ProductService;

public interface IProductService
{
    Task<bool> AddAsync(ProductInDTO product);

    Task<bool> UpdateAsync(int id, ProductInDTO product);

    Task<Product> GetByIdAsync(int id);

    Task<IEnumerable<ProductOutDTO>> GetAllAsync();
}