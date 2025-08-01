
using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IProductRepository
{
    Task<bool> AddAsync(Product product);

    Task<bool> UpdateAsync(Product product);

    Task<Product> GetByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllAsync();
}