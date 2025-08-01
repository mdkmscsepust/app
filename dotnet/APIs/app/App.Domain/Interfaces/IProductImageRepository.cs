

using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IProductImageRepository
{
    Task<bool> AddAsync(ProductImage productImage);
    Task<IEnumerable<ProductImage>> GetAllAsync();
    Task<ProductImage> GetByIdAsync(int id);
    Task<bool> DeleteAsync(ProductImage productImage);
}