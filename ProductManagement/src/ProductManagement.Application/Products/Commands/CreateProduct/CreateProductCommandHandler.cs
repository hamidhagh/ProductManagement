using Mapster;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();

            var productAddResult = await _productRepository.AddProductAsync(product);

            return productAddResult.Adapt<ProductDto>();
        }
    }
}
