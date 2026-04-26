using CleanArchitectureApi.Application.Features.Categories;
using CleanArchitectureApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        var createdCategory = await _mediator.Send(new CreateCategoryCommand(category.Name));
        return Ok(createdCategory);
    }
}
