using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ValidatedTypeSafeEnums.Exceptions;
using ValidatedTypeSafeEnums.Extensions;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Validation;

public class TypeSafeEnumValidator<T> : ITypeSafeEnumValidator<T> where T : DbContext
{
    private readonly T _context; 
    private readonly string _propertyMap = "Name";

    public TypeSafeEnumValidator(T context) => _context = context;

    public void EnsureTypeSafeEnumValidation()
    { 
        var assembly = Assembly.GetAssembly(typeof(TypeSafeEnum<>));
        if (assembly != null)
        {
            var enumBaseFields = GetEnumBaseFieldInfo();
            var enumTypes = assembly.GetTypes().Where(type => type.IsTypeSafeEnum());
            var dbSetTypes = _context.GetDbSetTypes();
            foreach (var enumType in enumTypes)
            {
                var enumPrefix = enumType.GetTypeSafeEnumPrefix();
                var dbSetType = dbSetTypes.First(type => type.Name == enumPrefix);
                var dbSet = _context.Set(dbSetType);
                foreach (var element in dbSet)
                {
                    var enumFieldInfo = GetEnumMappingFieldInfo(enumType, dbSetType, element);
                    if (enumFieldInfo != null)
                    {
                        var enumValue = enumFieldInfo.GetValue(null) as TypeSafeEnumBase;
                        if (enumValue != null)
                        {
                            foreach (var enumField in enumBaseFields)
                            {                               
                                var elementPropertyInfo = dbSetType.GetProperty(enumField.Name);
                                if (elementPropertyInfo != null)
                                {
                                    dynamic enumFieldValue = enumField.GetValue(enumValue);
                                    dynamic elementPropertyValue = elementPropertyInfo.GetValue(element);
                                    if (enumFieldValue != elementPropertyValue)
                                    {
                                        throw new InconsistentEnumException(
                                            enumType.Name, 
                                            enumField.Name,
                                            Convert.ToString(enumFieldValue),
                                            Convert.ToString(elementPropertyValue)
                                        );
                                    }
                                }
                                else
                                {
                                    throw new Exception($"The enum field \"{enumField.Name}\" is not present in the entity \"{dbSetType.Name}\".");
                                }
                            }
                        }
                        else
                        {
                            throw new MissingBaseClassException(enumType.Name);
                        }
                    }
                    else
                    {
                        throw new EnumNotFoundException(enumType.Name, _propertyMap);
                    }
                }
            }
        }
        else
        {
            throw new AssemblyNotFoundException(
                typeof(TypeSafeEnum<>).Name, 
                nameof(EnsureTypeSafeEnumValidation)
            );
        }
    }

    private FieldInfo? GetEnumMappingFieldInfo(Type enumType, Type dbSetType, object? element)
    {
        var mapProperty = dbSetType.GetProperty(_propertyMap);
        if (mapProperty != null)
        {
            var elementMap = (string?)mapProperty.GetValue(element);
            if (!string.IsNullOrEmpty(elementMap))
            {
                return enumType.GetField(
                    elementMap.Clean(), 
                    BindingFlags.Public | BindingFlags.Static
                );
            }           
        }

        return null;
    }

    private IEnumerable<FieldInfo> GetEnumBaseFieldInfo() =>
        typeof(TypeSafeEnumBase)
            .GetFields(BindingFlags.Public | BindingFlags.Instance)
            .Where(fieldInfo => fieldInfo.Name != _propertyMap);
}