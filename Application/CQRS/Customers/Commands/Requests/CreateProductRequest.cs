using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customers.Commands.Requests;

public class CreateProductRequest : IRequest<Result<CreateProductResponse>>
{
    public string Name { get; set; }
}
