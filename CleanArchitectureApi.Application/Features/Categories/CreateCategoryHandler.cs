using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Categories;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();

        return category;
    }
}
