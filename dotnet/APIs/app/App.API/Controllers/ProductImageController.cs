using App.Application.Interfaces;
using App.Application.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController(IProductImageService _productImageService, IFileService fileService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add(int productId,IFormFile request)
        {

            using var ms = new MemoryStream();
            await request.CopyToAsync(ms);

            var uploadInDTO = new FileUploadInDTO
            {
                FileName = request.FileName,
                FileContent = ms.ToArray()
            };

            var productImageInDTO = new ProductImageInDTO
            {
                ImageUrl = await fileService.UploadFileAsync(uploadInDTO),
                ProductId = productId
            };

            if (await _productImageService.AddAsync(productImageInDTO))
            {
                return Ok("Product image added successfully");
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var images = await _productImageService.GetAllAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var image = await _productImageService.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpDelete("{filePath}")]
        public IActionResult Delete(string filePath)
        {
            _productImageService.DeleteAsync(filePath);
            return NoContent();
        }
    }
}