﻿using ErrorOr;
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

namespace ProductManagement.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ErrorOr<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly Mapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, Mapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ErrorOr<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(request.id);

            if (product == null)
            {
                return Error.NotFound(description: "Product not found");
            }
            //if (await _productRepository.GetByIdAsync(request.id) is not Product product)
            //{
            //    return Error.NotFound(description: "Product not found");
            //}

            return product.Adapt<ProductDto>();
        }
    }
}
