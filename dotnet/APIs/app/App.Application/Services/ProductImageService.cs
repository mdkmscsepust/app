using App.Application.Interfaces;
using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;
using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Services;

public class ProductImageService(IFileService fileService,
IProductImageRepository _productImageRepository) : IProductImageService
{
    public async Task<bool> AddAsync(ProductImageInDTO request)
    {
        try
        {
            var productImage = new ProductImage
            {
                ImageUrl = request.ImageUrl,
                ProductId = request.ProductId
            };
            var result = await _productImageRepository.AddAsync(productImage);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding product image", ex);
        }
    }

    public void DeleteAsync(string filePath)
    {
        try
        {
            fileService.DeleteFile(filePath);
            var productImage = new ProductImage { ImageUrl = filePath };
            Task.Run(() => _productImageRepository.DeleteAsync(productImage));
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting product image", ex);
        }
    }

    public async Task<IEnumerable<ProductImageOutDTO>> GetAllAsync()
    {
        var productImages = await _productImageRepository.GetAllAsync();
        var productImageList = new List<ProductImageOutDTO>();
        foreach (var image in productImages)
        {
            productImageList.Add(new ProductImageOutDTO
            {
                ImageUrl = image.ImageUrl,
                ProductId = image.ProductId
            });
        }
        return productImageList;
    }

    public async Task<ProductImageOutDTO> GetByIdAsync(int id)
    {
        try
        {
            var productImage = await _productImageRepository.GetByIdAsync(id);
            if (productImage == null)
            {
                throw new Exception("Product image not found");
            }

            return new ProductImageOutDTO{
                ImageUrl = productImage.ImageUrl,
                ProductId = productImage.ProductId
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving product image by ID", ex);
        }
    }
}