using app.Models;
using app.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        if (await _productService.AddAsync(product))
        {
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        if (await _productService.UpdateAsync(product))
        {
            return NoContent();
        }
        return BadRequest();
    }
}