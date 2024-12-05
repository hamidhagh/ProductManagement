using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Application;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Common.Interfaces;
using ProductManagement.Infrastructure;
using ProductManagement.Infrastructure.Authentication.PasswordHasher;
using ProductManagement.Infrastructure.Authentication.TokenGenerator;
using ProductManagement.Infrastructure.Common.Persistence;
using ProductManagement.Infrastructure.Products.Persistence;
using ProductManagement.Infrastructure.Users.Persistence;
using System.Text;

namespace ProductManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddAuthentication(configuration)
                .AddPersistence(configuration);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ProductManagementDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            //return services;
            var config = configuration;
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            services.AddDbContext<ProductManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(ProductManagementApplication).Assembly));
            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.Section, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                });


            return services;
        }
    }
}
