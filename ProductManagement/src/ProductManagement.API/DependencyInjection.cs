﻿using ProductManagement.API.Services;
using ProductManagement.Application.Common.Interfaces;

namespace ProductManagement.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddProblemDetails();
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

            return services;
        }
    }
}