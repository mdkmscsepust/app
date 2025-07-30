namespace app.Services;

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Sms: {message}");
    }
}