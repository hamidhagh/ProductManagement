using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Queries.GetProductNoTracking
{
    public class GetProductNoTrackingQueryHandler : IRequestHandler<GetProductNoTrackingQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductNoTrackingQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(GetProductNoTrackingQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdNoTrackingAsync(request.id);

            //if (product == null)
            //{
            //    return Error.NotFound(description: "Product not found");
            //}
            //if (await _productRepository.GetByIdAsync(request.id) is not Product product)
            //{
            //    return Error.NotFound(description: "Product not found");
            //}

            return product.Adapt<ProductDto>();
        }
    }
}
