using App.Domain.ValueObject;

namespace App.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public Email Email { get; set; }
    public Contact Contact { get; set; }
}