﻿using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Application.Common.Models;
using System.Security.Claims;
using Throw;

namespace ProductManagement.API.Services
{
    public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
    {
        public CurrentUser GetCurrentUser()
        {
            _httpContextAccessor.HttpContext.ThrowIfNull();

            var id = GetClaimValues("id")
                .Select(Guid.Parse)
                .First();

            var permissions = GetClaimValues("permissions");
            var roles = GetClaimValues(ClaimTypes.Role);

            return new CurrentUser(Id: id, Permissions: permissions, Roles: roles);
        }

        private IReadOnlyList<string> GetClaimValues(string claimType)
        {
            return _httpContextAccessor.HttpContext!.User.Claims
                .Where(claim => claim.Type == claimType)
                .Select(claim => claim.Value)
                .ToList();
        }
    }
}
