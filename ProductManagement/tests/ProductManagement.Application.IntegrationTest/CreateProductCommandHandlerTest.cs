//using FluentAssertions;
//using MapsterMapper;
//using NSubstitute;
//using ProductManagement.Application.Common.DTOs;
//using ProductManagement.Application.Common.Interfaces;
//using ProductManagement.Application.Products.Commands.CreateProduct;
//using ProductManagement.Domain.Products;
//using ProductManagement.Domain.Users;

//namespace ProductManagement.Application.IntegrationTest
//{
//    public class CreateProductCommandHandlerTest
//    {
//        [Fact]
//        public async Task Handle_ShouldCreateProductAndReturnProductDto()
//        {
//            // Arrange
//            var productRepository = Substitute.For<IProductRepository>();
//            var mapper = Substitute.For<Mapper>();
            
//            var command = new CreateProductCommand(
//                Name: "Test Product",
//                ProduceDate: new DateTime(2024, 12, 5),
//                ManufacturePhone: "09121234567",
//                ManufactureEmail: "test@gmail.com",
//                IsAvailable: true,
//                UserId: Guid.NewGuid()
//            );

//            var product = new Product
//            {
//                Id = Guid.NewGuid(),
//                Name = command.Name,
//                ProduceDate = command.ProduceDate,
//                ManufacturePhone = command.ManufacturePhone,
//                ManufactureEmail = command.ManufactureEmail,
//                IsAvailable = command.IsAvailable,
//                UserId = command.UserId
//            };

//            var productDto = new ProductDto
//            {
//                Id = product.Id.ToString(),
//                Name = product.Name,
//                ProduceDate = product.ProduceDate.ToString("yyyy-MM-dd"),
//                ManufacturePhone = product.ManufacturePhone,
//                ManufactureEmail = product.ManufactureEmail,
//                IsAvailable = product.IsAvailable,
//                UserId = product.UserId
//            };

//            mapper.From(command).AdaptToType<Product>().Returns(product);
//            productRepository.AddProductAsync(product).Returns(Task.FromResult(product));
//            mapper.From(product).AdaptToType<ProductDto>().Returns(productDto);

//            var handler = new CreateProductCommandHandler(productRepository, mapper);

//            // Act
//            var result = await handler.Handle(command, CancellationToken.None);

//            // Assert
//            result.Should().BeEquivalentTo(productDto);
//            await productRepository.Received(1).AddProductAsync(product);
//            mapper.Received(1).From(command).AdaptToType<Product>();
//            mapper.Received(1).From(product).AdaptToType<ProductDto>();
//        }
//    }
//}