using System.Reflection;

namespace ValidatedTypeSafeEnums.TypeSafeEnums;

#pragma warning disable CS8600, CS8603, CS8618, CS8619

public abstract class TypeSafeEnum<T> : TypeSafeEnumBase
{
    public TypeSafeEnum(int enumId, string enumName) : base(enumId, enumName) 
    {
    }

    public static T GetValue(int enumId) =>
        GetValues().FirstOrDefault(value => 
            (value as TypeSafeEnumBase)?.Id == enumId
        );

    public static T GetValue(string enumName) =>
        GetValues().FirstOrDefault(value => 
            (value as TypeSafeEnumBase)?.Name == enumName
        );

    public static IEnumerable<T> GetValues() =>
        typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field => (T)field.GetValue(null));
}