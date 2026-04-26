using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public record UpdateProductCommand(
    int Id,
    string Name,
    decimal Price,
    int CategoryId) : IRequest<bool>;
