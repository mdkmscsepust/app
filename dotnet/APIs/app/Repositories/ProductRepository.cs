using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Product product)
    {
        await _dbContext.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id) ?? new Product();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
    }
}