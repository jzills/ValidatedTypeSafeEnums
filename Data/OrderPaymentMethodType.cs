using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class OrderPaymentMethodType : ITypeSafeEnum
{
    public int Id { get; set; }
    public string Name { get; set; }
}