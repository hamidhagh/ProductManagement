﻿using ErrorOr;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Authentication.Common;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Common.Interfaces;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly Mapper _mapper;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator, Mapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email))
            {
                return Error.Conflict(description: "User already exists");
            }

            var hashPasswordResult = _passwordHasher.HashPassword(request.Password);

            if (hashPasswordResult.IsError)
            {
                return hashPasswordResult.Errors;
            }

            var user = _mapper.From(request).AdaptToType<User>();

            await _userRepository.AddUserAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
