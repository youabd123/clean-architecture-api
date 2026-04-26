using CleanArchitectureApi.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureApi.Application.Features.Products;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _repository.GetByIdAsync(request.Id);

        if (existingProduct == null)
            return false;

        existingProduct.Name = request.Name;
        existingProduct.Price = request.Price;
        existingProduct.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(existingProduct);
        await _repository.SaveChangesAsync();

        return true;
    }
}
