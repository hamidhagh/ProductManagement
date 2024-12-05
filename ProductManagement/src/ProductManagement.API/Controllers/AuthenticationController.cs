using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Authentication.Commands.Register;
using ProductManagement.Application.Authentication.Common;
using ProductManagement.Application.Authentication.Queries.Login;
using ProductManagement.Application.DTOs.Authentication;

namespace ProductManagement.API.Controllers
{
    public class AuthenticationController(ISender _mediator) : ApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var command = new RegisterCommand(
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Password);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => base.Ok(MapToAuthResponse(authResult)),
                Problem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == AuthenticationErrors.InvalidCredentials)
            {
                return Problem(
                    detail: authResult.FirstError.Description,
                    statusCode: StatusCodes.Status401Unauthorized);
            }

            return authResult.Match(
                authResult => Ok(MapToAuthResponse(authResult)),
                Problem);
        }

        private static AuthenticationResponseDto MapToAuthResponse(AuthenticationResult authResult)
        {
            return new AuthenticationResponseDto(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }
    }
}
