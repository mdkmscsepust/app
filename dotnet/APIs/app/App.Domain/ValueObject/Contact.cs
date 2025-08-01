using System.Text.RegularExpressions;

namespace App.Domain.ValueObject;

public class Contact
{
    public string CounrtyCode { get; set; }
    public string Number { get; set; }
    public Contact() { }
    public Contact(string counrtyCode, string number)
    {
        if (!Regex.IsMatch(number, @"^\S+01\S$")) throw new ArgumentException("Invalid contact");
        Number = number;
        CounrtyCode = counrtyCode;
    }
    public string Full => $"+{CounrtyCode}-{Number}";
}