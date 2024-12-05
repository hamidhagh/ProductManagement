using Mapster;
using ProductManagement.Application.Common.DTOs;
using ProductManagement.Application.Products.Commands.CreateProduct;
using ProductManagement.Application.Products.Commands.UpdateProduct;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Common.Mappings
{
    public class ProductMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductCommand, Product>();
            config.NewConfig<UpdateProductCommand, Product>();
            config.NewConfig<List<CreateProductCommand>, List<Product>>();
            config.NewConfig<List<UpdateProductCommand>, List<Product>>();
            config.NewConfig<Product, ProductDto>()
              .Map(dest => dest.Id, src => src.Id.ToString())
              .Map(dest => dest.ProduceDate, src => src.ProduceDate.ToString("yyyy-MM-dd"))
              .Map(dest => dest.Name, src => src.Name)
              .Map(dest => dest.ManufacturePhone, src => src.ManufacturePhone)
              .Map(dest => dest.ManufactureEmail, src => src.ManufactureEmail)
              .Map(dest => dest.IsAvailable, src => src.IsAvailable)
              .Map(dest => dest.UserId, src => src.UserId);


        }
    }
}
