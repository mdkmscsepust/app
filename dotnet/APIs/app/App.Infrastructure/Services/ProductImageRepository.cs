using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class ProductImageRepository(ApplicationDbContext _dbContext) : IProductImageRepository
{
    public async Task<bool> AddAsync(ProductImage productImage)
    {
        try
        {
            await _dbContext.AddAsync(productImage);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding product image", ex);
        }
    }

    public async Task<bool> DeleteAsync(ProductImage productImage)
    {
        try
        {
            _dbContext.Remove(productImage);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting product image", ex);
        }
    }

    public async Task<IEnumerable<ProductImage>> GetAllAsync()
    {
        try
        {
            return await _dbContext.ProductImages.Include(x => x.Product).AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving product images", ex);
        }
    }

    public async Task<ProductImage> GetByIdAsync(int id)
    {
        try
        {
            return await _dbContext.ProductImages.FindAsync(id) ?? new ProductImage();
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving product image by ID", ex);
        }
    }
}