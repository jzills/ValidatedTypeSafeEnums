using Source.TypeSafeEnums;

namespace Source.Enums;

public sealed class OrderPaymentMethodTypeEnum : TypeSafeEnum<OrderPaymentMethodTypeEnum>
{
    public static OrderPaymentMethodTypeEnum Credit = new OrderPaymentMethodTypeEnum(1, nameof(Credit));
    public static OrderPaymentMethodTypeEnum Debit  = new OrderPaymentMethodTypeEnum(2, nameof(Debit));
    public static OrderPaymentMethodTypeEnum Check  = new OrderPaymentMethodTypeEnum(3, nameof(Check));

    private OrderPaymentMethodTypeEnum(int enumId, string enumLabel) : base(enumId, enumLabel) 
    {
    }
}