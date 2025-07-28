public class NotificationService
{
    public void OnOrderPlaced(object sender, OrderPlacedEvent e)
    {
        Console.WriteLine($"Order placed: {e.OrderId} at {e.DatePlacedAt}");
    }

    public void OnUserRegistered(object sender, UserRegisteredEventArgs e)
    {
        Console.WriteLine($"User registered: {e.Username}, Email: {e.Email}");
    }
}