using System.Reflection;

namespace ValidatedTypeSafeEnums.TypeSafeEnums;

#pragma warning disable CS8618, CS8600, CS8619

public abstract class TypeSafeEnum<T> : TypeSafeEnumBase
{
    public TypeSafeEnum(int id, string name)
        : base(id, name) {}

    public static List<T> GetValues() =>
        typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field => (T)field.GetValue(null))
            .ToList();
}