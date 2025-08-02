
namespace App.Application.Models.RequestModels;

public class UserInDTO
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCode { get; set; }
    public bool Status { get; set; } = true;
}