using ErrorOr;
using MediatR;
using ProductManagement.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName,
    string LastName,
    string Phone,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
