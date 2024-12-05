//using FluentAssertions;
//using NSubstitute;
//using ProductManagement.Domain.Common.Interfaces;
//using ProductManagement.Domain.Users;

//namespace ProductManagement.Domain.IntegrationTest
//{
//    public class PasswordHasherTest
//    {
//        [Fact]
//        public void IsCorrectPasswordHash_WhenPasswordIsCorrect_ShouldReturnTrue()
//        {
//            // Arrange
//            var password = "correctPassword";
//            var passwordHash = "hashedCorrectPassword";

//            var passwordHasher = Substitute.For<IPasswordHasher>();
//            passwordHasher.IsCorrectPassword(password, passwordHash).Returns(true);

//            var user = new User
//            {
//                PasswordHash = passwordHash
//            };

//            // Act
//            var result = user.IsCorrectPasswordHash(password, passwordHasher);

//            // Assert
//            result.Should().BeTrue();
//            passwordHasher.Received(1).IsCorrectPassword(password, passwordHash);
//        }
//    }
//}