using CleanArchitectureApi.Domain.Entities;

namespace CleanArchitectureApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task SaveChangesAsync();
}
