using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Categories.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return Ok(category);
    }
}
