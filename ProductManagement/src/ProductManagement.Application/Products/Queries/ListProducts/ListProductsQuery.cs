using MediatR;
using ProductManagement.Application.Common;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Queries.ListProducts
{
    public record ListProductsQuery(SearchParams SearchParams) : IRequest<List<ProductDto>>
    {
    }
}
