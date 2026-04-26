using CleanArchitectureApi.Application.Features.Products;
using CleanArchitectureApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var createdProduct = await _mediator.Send(
            new CreateProductCommand(product.Name, product.Price, product.CategoryId));

        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var updated = await _mediator.Send(
            new UpdateProductCommand(id, product.Name, product.Price, product.CategoryId));

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteProductCommand(id));

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
