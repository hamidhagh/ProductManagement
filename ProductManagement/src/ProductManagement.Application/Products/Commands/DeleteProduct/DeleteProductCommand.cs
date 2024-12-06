using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id, string Name, DateTime ProduceDate, string ManufacturePhone,
        string ManufactureEmail, bool IsAvailable, Guid UserId) : IRequest
    {
    }
}
