using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;
using CleanArchitectureApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApi.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
