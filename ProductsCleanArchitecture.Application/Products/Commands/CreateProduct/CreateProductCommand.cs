using MediatR;

namespace ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, decimal Price) : IRequest<int>;