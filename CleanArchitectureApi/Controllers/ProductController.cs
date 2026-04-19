using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var existingProduct = await _repository.GetByIdAsync(id);

        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;

        await _repository.UpdateAsync(existingProduct);
        await _repository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        await _repository.DeleteAsync(product);
        await _repository.SaveChangesAsync();

        return NoContent();
    }
}