public class OrderService
{
    public event EventHandler<OrderPlacedEvent>? OrderPlaced;

    public void PlaceOrder(int orderId)
    {
        OnOrderPlaced(new OrderPlacedEvent(orderId));
    }
    protected virtual void OnOrderPlaced(OrderPlacedEvent e)
    {
        OrderPlaced?.Invoke(this, e);
    }
}