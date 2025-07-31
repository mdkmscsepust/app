using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories.ProductImageRepository;

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