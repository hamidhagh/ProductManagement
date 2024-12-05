//using FluentValidation;
//using Mapster;
//using MapsterMapper;
//using Microsoft.Extensions.DependencyInjection;
//using ProductManagement.Application.Common.Behaviors;
//using System.Reflection;

//namespace ProductManagement.Application
//{
//    public static class DependencyInjection
//    {
//        public static IServiceCollection AddApplication(this IServiceCollection services)
//        {
//            services.AddMediatR(options =>
//            {
//                options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

//                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
//                //options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
//            });

//            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

//            //services.AddMapster();
//            //var config = TypeAdapterConfig.GlobalSettings;
//            //config.Scan(Assembly.GetExecutingAssembly());

//            //// Register the mapper
//            //services.AddSingleton(config);
//            //services.AddScoped<IMapper, ServiceMapper>();
//            //services.AddScoped<IMapper, Mapper>();

//            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
//            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
//            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
//            // register the mapper as Singleton service for my application
//            var mapperConfig = new Mapper(typeAdapterConfig);
//            services.AddSingleton<IMapper>(mapperConfig);

//            return services;
//        }
//    }
//}
