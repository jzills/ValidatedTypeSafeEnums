using Microsoft.EntityFrameworkCore;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Extensions;

public static class TypeExtensions
{
    public static bool IsTypeSafeEnum(this Type type) => 
        type.IsClass && !type.IsAbstract && 
        type.IsSubclassOf(typeof(TypeSafeEnumBase));

    public static bool IsDbSet(this Type type) =>
        type.IsGenericType && 
        typeof(DbSet<>).IsAssignableFrom(type.GetGenericTypeDefinition());
}