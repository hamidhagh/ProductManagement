using FluentAssertions;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Users;

namespace ProductManagement.Domain.UnitTest
{
    public class ProductTests
    {
        [Fact]
        public void Product_WhenValidProductAndUser_ShouldMatch()
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Test",
                LastName = "Test",
                Phone = "09121234567",
                Email = "Test@gmail.com",
                PasswordHash = "test"
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                ProduceDate = DateTime.Now,
                ManufacturePhone = "09121234567",
                ManufactureEmail = "test@gmail.com",
                IsAvailable = true,
                User = user,
                UserId = user.Id
            };

            product.User.Should().NotBeNull();
            product.UserId.Should().Be(user.Id);
            product.User.FirstName.Should().Be("Test");
            product.User.LastName.Should().Be("Test");
        }

        [Fact]
        public void Product_WhenUpdatingFields_ShouldBeAllowed()
        {
            // Arrange
            var product = new Product();
            var user = new User();

            // Act
            product.Name = "Test";
            product.ProduceDate = DateTime.Now;
            product.ManufacturePhone = "09121234567";
            product.ManufactureEmail = "test@gmail.com";
            product.IsAvailable = true;
            product.User = user;
            product.UserId = user.Id;

            // Assert
            product.Name.Should().Be("Test");
            product.ManufacturePhone.Should().Be("09121234567");
            product.ManufactureEmail.Should().Be("test@gmail.com");
        }
    }
}