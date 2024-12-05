//using FluentAssertions;
//using ProductManagement.Domain.Users;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ProductManagement.Domain.UnitTest
//{
//    public class UserTests
//    {
//        [Fact]
//        public void Product_WhenUpdatingFields_ShouldBeAllowed()
//        {
//            // Arrange
//            var user = new User();

//            // Act
//            user.FirstName = "Test";
//            user.LastName = "Test";
//            user.Phone = "09121234567";
//            user.Email = "test@gmail.com";
//            user.PasswordHash = "hashedpassword";

//            // Assert
//            user.FirstName.Should().Be("Test");
//            user.LastName.Should().Be("Test");
//            user.Phone.Should().Be("09121234567");
//            user.Email.Should().Be("test@gmail.com");
//            user.PasswordHash.Should().Be("hashedpassword");
//        }
//    }
//}
