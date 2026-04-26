using CleanArchitectureApi.Domain.Entities;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public record CreateProductCommand(
    string Name,
    decimal Price,
    int CategoryId) : IRequest<Product>;
