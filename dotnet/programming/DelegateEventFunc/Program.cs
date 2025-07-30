using Microsoft.Extensions.DependencyInjection;
// ...existing code...
var service = new ServiceCollection();
service.AddScoped<OrderService>();
service.AddScoped<NotificationService>();
var provider = service.BuildServiceProvider();

var orderService = provider.GetRequiredService<OrderService>();
var notificationService = provider.GetRequiredService<NotificationService>();
orderService.OrderPlaced += notificationService.OnOrderPlaced;
orderService.PlacedOrder(1, "masumcsepust@gmail.com");
public class OrderEventArgs : EventArgs
{
    public int OrderId { get; }
    public string Username { get; }
    public OrderEventArgs(int orderId, string username)
    {
        OrderId = orderId;
        Username = username;
    }
}

public class OrderService
{
    public event EventHandler<OrderEventArgs> OrderPlaced;
    public void PlacedOrder(int orderId, string username)
    {
        OrderPlaced?.Invoke(this, new OrderEventArgs(orderId, username));
    }
}

public class NotificationService
{
    public void OnOrderPlaced(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"Notification Order Placed: OrderId = {e.OrderId} Username = {e.Username}");
    }
}