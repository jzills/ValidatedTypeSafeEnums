using Source.TypeSafeEnums;

namespace Source.Enums;

public sealed class OrderTypeEnum : TypeSafeEnum<OrderTypeEnum>
{
    public static OrderTypeEnum InStore = new OrderTypeEnum(1, "In Store");
    public static OrderTypeEnum Pickup  = new OrderTypeEnum(2, nameof(Pickup));
    public static OrderTypeEnum Online  = new OrderTypeEnum(3, nameof(Online));

    private OrderTypeEnum(int enumId, string enumLabel) : base(enumId, enumLabel) 
    {
    }
}