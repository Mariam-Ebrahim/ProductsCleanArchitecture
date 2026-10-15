using MediatR;
using ProductsCleanArchitecture.Application.Interfaces;

namespace ProductsCleanArchitecture.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return false;

        product.Name = request.Name;
        product.Price = request.Price;

        await _repository.UpdateAsync(product, cancellationToken);

        return true;
    }
}