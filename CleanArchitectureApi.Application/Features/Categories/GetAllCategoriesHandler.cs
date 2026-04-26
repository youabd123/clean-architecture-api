using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Categories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _repository;

    public GetAllCategoriesHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
