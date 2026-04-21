using MediatR;
using CleanArchitectureApi.Domain.Entities;

namespace CleanArchitectureApi.Application.Features.Products;

public record GetProductByIdQuery(int Id) : IRequest<Product?>;
