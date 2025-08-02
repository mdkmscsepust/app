using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Domain.ValueObject;

public class Email
{
    public string Value { get; }
    public Email() { }
    public Email(string email)
    {
        if (!IsValid(email)) throw new ArgumentException("invalid email");
        Value = email;
    }
    public bool IsValid(string email)
    {
        return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^\S+@\S+\.\S+$");
    }
}