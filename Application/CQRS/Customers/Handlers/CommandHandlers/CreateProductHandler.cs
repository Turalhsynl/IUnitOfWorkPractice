using Application.CQRS.Customers.Commands.Requests;
using Application.CQRS.Customers.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Handlers.CommandHandlers
{
    class CreateProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = request.Name
            };

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new Result<CreateProductResponse>
                {
                    Data = null,
                    Errors = ["Product can't empty"],
                    IsSuccess = false
                };
            }

            await _unitOfWork.ProductRepository.AddAsync(product);

            CreateProductResponse response = new()
            {
                Id = product.Id,
                Name = request.Name
            };

            return new Result<CreateProductResponse> { Data = response, Errors = [], IsSuccess = true };
        }
    }
}
