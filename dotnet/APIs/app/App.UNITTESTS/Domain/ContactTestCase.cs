using App.Domain.ValueObject;
using FluentAssertions;

namespace App.UNITTESTS.Domain;

public class ContactTestCase
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("0")]
    [InlineData("01")]
    [InlineData("0100000000")]
    [InlineData("010000000000")]
    public void CreateContact_WithInvalidNumber_ThrowsArgumenException(string number)
    {
        // Arrange
        var countryCode = "88";

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Contact(countryCode, number));
        Assert.Equal("Invalid mobile number", ex.Message);
    }


    [Fact]
    public void CreateContact_WithValidNumber_CreateContactSuccessfully()
    {
        // Arrange
        var number = "01000000000";
        var countryCode = "88";

        // Act 
        var actualContact = new Contact(countryCode, number);

        // Assert
        // C# raw
        // Assert.Equal(expected: number, actual: actualContact.Number);
        // Assert.Equal(expected: countryCode, actual: actualContact.CountryCode);
        // Assert.Equal(expected: $"+{countryCode}-{number}", actual: actualContact.Full);

        // Fluent Assertions
        actualContact.Number.Should().Be(number);
        actualContact.CountryCode.Should().Be(countryCode);
        actualContact.Full.Should().Be($"+{countryCode}-{number}");
    }
}