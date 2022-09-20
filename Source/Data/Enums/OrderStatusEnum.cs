using Source.TypeSafeEnums;

namespace Source.Enums;

public sealed class OrderStatusEnum : TypeSafeEnum<OrderStatusEnum>
{
    public static OrderStatusEnum Pending   = new OrderStatusEnum(1, nameof(Pending));
    public static OrderStatusEnum Purchased = new OrderStatusEnum(2, nameof(Purchased));
    public static OrderStatusEnum Received  = new OrderStatusEnum(3, nameof(Received));

    private OrderStatusEnum(int enumId, string enumLabel) : base(enumId, enumLabel) 
    {
    }
}