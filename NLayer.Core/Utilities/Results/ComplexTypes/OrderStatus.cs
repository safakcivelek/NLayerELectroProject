namespace NLayer.Core.Utilities.Results.ComplexTypes
{
    public enum OrderStatus
    {
        // Sipariş Durumu
        ReceivedOrder = 0,
        ConfirmedOrder = 1,
        PreparingOrder = 2,
        CancelledOrder = 3,
        ShippedOrder = 4,
        OnTheWayOrder = 5,
        DeliveredOrder = 6,
    }
}
