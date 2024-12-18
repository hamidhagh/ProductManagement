﻿using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(int Id, string Name, DateTime ProduceDate, string ManufacturePhone,
        string ManufactureEmail, bool IsAvailable, Guid UserId) : IRequest
    {
    }
}
