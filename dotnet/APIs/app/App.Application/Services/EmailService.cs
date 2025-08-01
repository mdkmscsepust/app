using App.Application.Interfaces;

namespace App.Application.Services;

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}