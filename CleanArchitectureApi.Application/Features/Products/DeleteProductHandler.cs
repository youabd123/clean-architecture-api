using CleanArchitectureApi.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return false;

        await _repository.DeleteAsync(product);
        await _repository.SaveChangesAsync();

        return true;
    }
}
