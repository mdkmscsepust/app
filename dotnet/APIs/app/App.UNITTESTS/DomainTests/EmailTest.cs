using App.Domain.ValueObject;

namespace App.UNITTESTS.DomainTests;

public class EmailTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("masumcsepust")]
    [InlineData("masumcsepust@")]
    [InlineData("masumcsepust@.")]
    [InlineData("masumcsepust@.com")]
    public void Email_WithInvalidFormat_ThrowsArgumentException(string email)
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Email(email));
        Assert.Equal("invalid email", ex.Message);
    }

    [Fact]
    public void Email_WithValidFormat_CreateEmailSuccessfully()
    {
        // Arrange
        var validEmail = "masumcsepust@gmail.com";
        // Act
        var actual = new Email(validEmail);
        // Assert
        Assert.Equal(expected: validEmail, actual:actual.Value);
    }
}