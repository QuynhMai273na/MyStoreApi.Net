using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Interfaces;
using MyStore.Application.DTOs;

namespace MyStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService) => _productService = productService;
    [HttpGet]
    public async Task<IActionResult> GetAll()=> Ok(await _productService.GetAllProductsAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _productService.GetProductByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest req)
    {
        var id = await _productService.CreateProductAsync(req);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductRequest req)
    {
        var updated = await _productService.UpdateProductAsync(id, req);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

}