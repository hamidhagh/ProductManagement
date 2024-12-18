﻿using ErrorOr;
using MediatR;
using ProductManagement.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
