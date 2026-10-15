using MediatR;
using ProductsCleanArchitecture.Application.Interfaces;

namespace ProductsCleanArchitecture.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return false;

        await _repository.DeleteAsync(product, cancellationToken);

        return true;
    }
}