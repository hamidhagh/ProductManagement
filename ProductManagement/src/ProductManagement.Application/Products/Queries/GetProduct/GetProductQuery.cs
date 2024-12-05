using ErrorOr;
using MediatR;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Queries.GetProduct
{
    public record GetProductQuery(int id) : IRequest<ProductDto>;    
}
