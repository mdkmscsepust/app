using App.Application.Models.RequestModels;
using App.Application.Services;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ValueObject;
using Moq;

namespace App.UNITTESTS.ApplicationTests;

public class UserServiceTests
{
    [Theory]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", null, true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", "", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", " ", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", "0100000000", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", "02", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.com", "88", "010000000000", true)]
    public async Task AddAsync_ShouldThrow_WhenPhoneNumberInvalid(string username, string email, string countryCode, string phoneNumber, bool status)
    {
        // Arrange
        var user = new UserInDTO
        {
            Username = username,
            Email = email,
            CountryCode = countryCode,
            PhoneNumber = phoneNumber,
            Status = status
        };

        var mockUser = new Mock<IUserRepository>();

        // Act

        var userService = new UserService(mockUser.Object);

        // Assert
        var ex = await Assert.ThrowsAsync<Exception>(async () => await userService.AddAsync(user));
        Assert.Equal("Invalid mobile number", ex.Message);
    }

    [Theory]
    [InlineData("xxxxxxxxx", "xxxxxxxxx", "88", "01000000000", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@", "88", "01000000000", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@.", "88", "01000000000", true)]
    [InlineData("xxxxxxxxx", "xxxxxxxxx@gmail.", "88", "01000000000", true)]
    public async Task AddAsync_ShouldThrow_WhenEmailInvalid(string username, string email, string countryCode, string phoneNumber, bool status)
    {
        // Arrange
        var user = new UserInDTO
        {
            Username = username,
            Email = email,
            CountryCode = countryCode,
            PhoneNumber = phoneNumber,
            Status = status
        };

        var mockUser = new Mock<IUserRepository>();

        // Act

        var userService = new UserService(mockUser.Object);

        // Assert
        var ex = await Assert.ThrowsAsync<Exception>(async () => await userService.AddAsync(user));
        Assert.Equal("invalid email", ex.Message);
    }
    
    [Fact]
    public async Task AddAsync_Should_Be_Success_WhenEmailValid()
    {
        // Arrange
        var user = new UserInDTO
        {
            Username = "xxxxxxxxx",
            Email = "xxxxxxxxx@gmail.com",
            CountryCode = "88",
            PhoneNumber = "01700000000",
            Status = true
        };

        var mockUser = new Mock<IUserRepository>();
        mockUser.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(true);

        var userService = new UserService(mockUser.Object);

        // Act
        var result = await userService.AddAsync(user);

        // Assert
        Assert.True(result);
    }
}