using System.Text.RegularExpressions;

namespace App.Domain.ValueObject;

public class Contact
{
    public string CountryCode { get; }
    public string Number { get; }
    public Contact() { }
    public Contact(string countryCode, string number)
    {
        if (!IsValid(number))
        {
            throw new ArgumentException("Invalid mobile number");
        }
        Number = number;
        CountryCode = countryCode;
    }
    public string Full => $"+{CountryCode}-{Number}";

    private bool IsValid(string number)
    {
        return !string.IsNullOrEmpty(number) && Regex.IsMatch(number, @"^01[0-9]{9}$");
    }
}