public class OrderPlacedEvent : EventArgs
{
    public int OrderId { get; }
    public DateTime DatePlacedAt { get; }
    public OrderPlacedEvent(int orderId)
    {
        OrderId = orderId;
        DatePlacedAt = DateTime.Now;
    }
}