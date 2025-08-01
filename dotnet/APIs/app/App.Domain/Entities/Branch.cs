using App.Domain.ValueObject;

namespace App.Domain.Entities;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Email Email { get; private set; }
    public Contact Contact { get; private set; }
    public Branch(){ }
    public Branch(string name, Email email, Contact contact)
    {
        Name = name;
        Email = email;
        Contact = contact;
    }
}