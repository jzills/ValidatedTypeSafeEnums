namespace ValidatedTypeSafeEnums.TypeSafeEnums;

public abstract class TypeSafeEnumBase
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TypeSafeEnumBase(int enumId, string enumName) => (Id, Name) = (enumId, enumName);

    public static implicit operator int(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Id;
    public static implicit operator string(TypeSafeEnumBase typeSafeEnum) => typeSafeEnum.Name;
}