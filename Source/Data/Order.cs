using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class Order
{
    public int Id { get; set; }
    public int OrderStatusId { get; set; }
    public int OrderTypeId { get; set; }
    public int OrderPaymentCycleId { get; set; }
    public int OrderPaymentMethodTypeId { get; set; }
    public int OrderShippingStatusId { get; set; }
    public DateTime PlacedOn { get; set; }
    public DateTime? ShippedOn { get; set; }
    public DateTime? DeliveredOn { get; set; }
}