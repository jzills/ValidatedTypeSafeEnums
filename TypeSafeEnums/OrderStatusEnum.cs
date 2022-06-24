namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public sealed class OrderStatusEnum : TypeSafeEnum<OrderStatusEnum>, ITypeSafeEnum
{
    public static OrderStatusEnum Pending = new OrderStatusEnum(1, nameof(Pending));
    public static OrderStatusEnum Purchased = new OrderStatusEnum(2, nameof(Purchased));
    public static OrderStatusEnum Received = new OrderStatusEnum(3, nameof(Received));

    private OrderStatusEnum(int enumId, string enumName) : base(enumId, enumName) 
    {
    }
}