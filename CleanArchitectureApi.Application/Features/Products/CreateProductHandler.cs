using CleanArchitectureApi.Domain.Entities;
using CleanArchitectureApi.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return product;
    }
}
