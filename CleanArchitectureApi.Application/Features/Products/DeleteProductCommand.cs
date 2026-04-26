using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public record DeleteProductCommand(int Id) : IRequest<bool>;
