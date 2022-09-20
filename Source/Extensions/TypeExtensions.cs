using Microsoft.EntityFrameworkCore;
using Source.TypeSafeEnums;

namespace Source.Extensions;

public static class TypeExtensions
{
    public static string GetTypeSafeEnumPrefix(this Type source) =>
        source.Name.Substring(0, source.Name.IndexOf("Enum"));

    public static bool IsTypeSafeEnum(this Type source) => 
        source.IsClass && !source.IsAbstract && 
        source.IsSubclassOf(typeof(TypeSafeEnumBase));

    public static bool IsDbSet(this Type source) =>
        source.IsGenericType && 
        typeof(DbSet<>).IsAssignableFrom(source.GetGenericTypeDefinition());
}