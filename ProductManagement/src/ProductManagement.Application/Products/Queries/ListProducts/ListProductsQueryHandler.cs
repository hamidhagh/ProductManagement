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

        public ListProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> Handle(ListProductsQuery? request, CancellationToken cancellationToken)
        {
            List<Product> products;
            if (!request.Id.HasValue)
            {
                return (await _productRepository.GetAllAsync()).Adapt<List<ProductDto>>();
            }
            products = await _productRepository.GetAllBySearchParamsAsync(request.Id);

            return products.Adapt<List<ProductDto>>();
        }
    }
}
