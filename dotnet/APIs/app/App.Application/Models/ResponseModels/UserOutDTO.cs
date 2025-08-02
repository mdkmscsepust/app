using App.Domain.ValueObject;

namespace App.Application.Models.ResponseModels;

public class UserOutDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public Email Email { get; set; }
    public Contact Contact { get; set; }
    public bool Status { get; set; } = true;
}