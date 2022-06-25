namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public abstract class TypeSafeEnumBase
{
    public readonly int Id;
    public readonly string Name;

    public TypeSafeEnumBase(int enumId, string enumName) => (Id, Name) = (enumId, enumName);

    public static implicit operator int(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Id;
    public static implicit operator string(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Name;
}