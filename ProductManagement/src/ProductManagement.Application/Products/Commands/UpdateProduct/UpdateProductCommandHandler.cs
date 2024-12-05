using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();

            await _productRepository.UpdateProductAsync(product);

            //return Task.CompletedTask;
        }
    }
}
