using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Source.Extensions;

public static class DbContextExtensions
{
#pragma warning disable CS8600, CS8602, CS8603
    public static IQueryable<object> Set(this DbContext context, Type type) =>
        (IQueryable<object>) context
            .GetType()
            .GetMethod("Set", types: Type.EmptyTypes)
            .MakeGenericMethod(type)
            .Invoke(context, null);
#pragma warning restore CS8600, CS8602, CS8603

    public static IEnumerable<Type> GetDbSetTypes<T>(this T _) where T : DbContext =>
        typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.PropertyType.IsDbSet())
            .Select(property => property.PropertyType.GetTypeInfo().GenericTypeArguments[0]);
}