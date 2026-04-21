using MediatR;
using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;

namespace CleanArchitectureApi.Application.Features.Products;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}