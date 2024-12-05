using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Common.Behaviors;

namespace ProductManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
                //options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            });

            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

            services.AddMapster();

            return services;
        }
    }
}
