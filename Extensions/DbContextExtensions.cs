using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Extensions;

public static class DbContextExtensions
{
    public static IQueryable<object> Set(this DbContext context, Type type)
    {
        var methodInfo = context
            .GetType()
            .GetMethod("Set", types: Type.EmptyTypes);
            
        if (methodInfo != null)
        {
            return (IQueryable<object>) methodInfo
                .MakeGenericMethod(type)
                .Invoke(context, null);
        }

        return null;
    } 

    public static IEnumerable<Type> GetDbSetTypes<T>(this T _) where T : DbContext =>
        typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(property => property.PropertyType.IsDbSet())
            .Select(property => property.PropertyType.GetTypeInfo().GenericTypeArguments[0]);
}