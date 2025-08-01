using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;
using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface IProductService
{
    Task<bool> AddAsync(ProductInDTO product);

    Task<bool> UpdateAsync(int id, ProductInDTO product);

    Task<Product> GetByIdAsync(int id);

    Task<IEnumerable<ProductOutDTO>> GetAllAsync();
}