using Mapster;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Queries.ListProducts
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly Mapper _mapper;

        public ListProductsQueryHandler(IProductRepository productRepository, Mapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products;
            if (request.SearchParams == null)
            {
                products = await _productRepository.GetAllAsync();
            }
            products = await _productRepository.GetAllBySearchParamsAsync(request.SearchParams);

            return products.Adapt<List<ProductDto>>();
        }
    }
}
