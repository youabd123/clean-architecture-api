using CleanArchitectureApi.Domain.Entities;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Categories;

public record CreateCategoryCommand(string Name) : IRequest<Category>;
