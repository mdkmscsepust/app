namespace app.Services;

public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}