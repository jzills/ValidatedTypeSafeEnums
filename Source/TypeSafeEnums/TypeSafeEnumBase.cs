namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public abstract class TypeSafeEnumBase
{
    public readonly int Id;

    [EnumToEntityMapping]
    public readonly string Label;

    public TypeSafeEnumBase(int enumId, string enumLabel) => (Id, Label) = (enumId, enumLabel);

    public static implicit operator int(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Id;
    public static implicit operator string(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Label;
    public void Deconstruct(out int enumId, out string enumLabel) => (enumId, enumLabel) = (Id, Label);
}