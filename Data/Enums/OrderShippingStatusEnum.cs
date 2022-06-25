using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Enums;

public sealed class OrderShippingStatusEnum : TypeSafeEnum<OrderShippingStatusEnum>
{
    public static OrderShippingStatusEnum ShippingLabelCreated = new OrderShippingStatusEnum(1, "Shipping Label Created");
    public static OrderShippingStatusEnum AwaitingPickup = new OrderShippingStatusEnum(2, "Awaiting Pickup");
    public static OrderShippingStatusEnum InTransit = new OrderShippingStatusEnum(3, "In Transit");
    public static OrderShippingStatusEnum Delivered = new OrderShippingStatusEnum(4, "Delivered");

    private OrderShippingStatusEnum(int enumId, string enumName) : base(enumId, enumName) 
    {
    }
}