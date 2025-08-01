using App.Application.Interfaces;

namespace App.Application.Services;

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Sms: {message}");
    }
}