using app.Models;
using app.Models.RequestModels;
using app.Models.ResponseModels;
using app.Repositories;

namespace app.Services.ProductService;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<bool> AddAsync(ProductInDTO request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };
        return await productRepository.AddAsync(product);
    }

    public async Task<bool> UpdateAsync(int id, ProductInDTO product)
    {
        var existingProduct = await productRepository.GetByIdAsync(id);
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;
        return await productRepository.UpdateAsync(existingProduct);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ProductOutDTO>> GetAllAsync()
    {
        var products = await productRepository.GetAllAsync();
        var productList = new List<ProductOutDTO>();
        foreach (var product in products)
        {
            productList.Add(new ProductOutDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category?.Id ?? 0,
                CategoryName = product.Category?.Name ?? "No Category"
            });
        }

        return productList;
    }
}