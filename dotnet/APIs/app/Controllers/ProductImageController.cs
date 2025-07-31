using app.Models.RequestModels;
using app.Services.ProductImageService;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController(IProductImageService _productImageService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductImageInDTO request)
        {
            if (await _productImageService.AddAsync(request))
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