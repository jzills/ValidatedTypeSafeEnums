using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ValidatedTypeSafeEnums.Extensions;

public static class DbContextExtensions
{
    public static IEnumerable<Type> GetDbSetTypes<T>(this T _) where T : DbContext =>
        typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.PropertyType.IsDbSet())
            .Select(property => property.PropertyType.GetTypeInfo().GenericTypeArguments[0]);
}