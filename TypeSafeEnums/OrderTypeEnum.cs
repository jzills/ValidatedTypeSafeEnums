namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public sealed class OrderTypeEnum : TypeSafeEnum<OrderTypeEnum>, ITypeSafeEnum
{
    public static OrderTypeEnum InStore = new OrderTypeEnum(1, "In Store");
    public static OrderTypeEnum Pickup = new OrderTypeEnum(2, nameof(Pickup));
    public static OrderTypeEnum Online = new OrderTypeEnum(3, nameof(Online));

    private OrderTypeEnum(int enumId, string enumName) : base(enumId, enumName) 
    {
    }
}