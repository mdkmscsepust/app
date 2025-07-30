using app.Models;
using app.Repositories;

namespace app.Services.ProductService;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<bool> AddAsync(Product product)
    {
        return await productRepository.AddAsync(product);
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        return await productRepository.UpdateAsync(product);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await productRepository.GetAllAsync();
    }
}