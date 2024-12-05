using ErrorOr;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Authentication.Common;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            return user is null || !user.IsCorrectPasswordHash(request.Password, _passwordHasher)
                ? AuthenticationErrors.InvalidCredentials
                : new AuthenticationResult(user, _jwtTokenGenerator.GenerateToken(user));
        }
    }
}
