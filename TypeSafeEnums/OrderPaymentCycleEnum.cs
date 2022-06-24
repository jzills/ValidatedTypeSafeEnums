namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public sealed class OrderPaymentCycleEnum : TypeSafeEnum<OrderPaymentCycleEnum>, ITypeSafeEnum
{
    public static OrderPaymentCycleEnum Month1 = new OrderPaymentCycleEnum(1, "1 Month");
    public static OrderPaymentCycleEnum Months3 = new OrderPaymentCycleEnum(2, "3 Months");
    public static OrderPaymentCycleEnum Months6 = new OrderPaymentCycleEnum(3, "6 Months");
    public static OrderPaymentCycleEnum Year1 = new OrderPaymentCycleEnum(4, "1 Year");

    private OrderPaymentCycleEnum(int enumId, string enumName) : base(enumId, enumName) 
    {
    }
}