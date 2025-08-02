using System.Net.Http.Json;
using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace App.UNITTESTS.IntegrationTests;

public class CustomWebAppFactory : WebApplicationFactory<Program>
{
}

public class UserControllerIntegrationTests : IClassFixture<CustomWebAppFactory>
{
    private readonly HttpClient _client;

    public UserControllerIntegrationTests(CustomWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUser_ReturnsSuccess()
    {
        // Act
        var response = await _client.GetAsync("/User/1");

        // Assert
        response.EnsureSuccessStatusCode();
        var user = await response.Content.ReadFromJsonAsync<UserOutDTO>();

        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async Task PostUser_Should_ReturnSuccess()
    {
        var user = new UserInDTO()
        {
            Username = "masumcsepust",
            Email = "masumcsepust@gmail.com",
            CountryCode = "88",
            PhoneNumber = "01684173432",
            Status = true
        };

        var response = await _client.PostAsJsonAsync("/User", user);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal("User added successfully", responseContent);
    }
    
}
