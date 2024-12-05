using MediatR;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name, DateTime ProduceDate, string? ManufacturePhone,
        string? ManufactureEmail, bool IsAvailable, Guid UserId) : IRequest<ProductDto>;
}
