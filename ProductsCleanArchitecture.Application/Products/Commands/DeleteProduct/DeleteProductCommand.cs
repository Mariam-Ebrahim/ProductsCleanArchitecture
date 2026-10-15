using MediatR;

namespace ProductsCleanArchitecture.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<bool>;