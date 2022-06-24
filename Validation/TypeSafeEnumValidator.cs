using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ValidatedTypeSafeEnums.Data;
using ValidatedTypeSafeEnums.Exceptions;
using ValidatedTypeSafeEnums.Extensions;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Validation;

public class TypeSafeEnumValidator<T> : ITypeSafeEnumValidator<T> where T : DbContext
{
    private readonly T _context; 

    public TypeSafeEnumValidator(T context) => _context = context;

    public void EnsureTypeSafeEnumValidation()
    {
        var assembly = Assembly.GetAssembly(typeof(TypeSafeEnum<>));
        if (assembly != null)
        {
            var dbSetTypes = _context.GetDbSetTypes();
            var enumTypes = assembly.GetTypes().Where(type => type.IsTypeSafeEnum());
            foreach (var enumType in enumTypes)
            {
                var matchingDbSetName = enumType.Name.Substring(0, enumType.Name.IndexOf("Enum"));
                var dbSetType = dbSetTypes.First(type => type.Name == matchingDbSetName);
                var dbSet = _context.Set(dbSetType) as IQueryable<ITypeSafeEnum>;
                if (dbSet != null)
                {
                    foreach (var element in dbSet)
                    {
                        var enumField = enumType.GetField(element.CleanName(), BindingFlags.Public | BindingFlags.Static);
                        if (enumField != null)
                        {
                            var enumValue = enumField.GetValue(null) as TypeSafeEnumBase;
                            if (enumValue != null)
                            {
                                var matchingEnum = dbSet.FirstOrDefault(element => element.Id == enumValue.Id);
                                if (matchingEnum == null)
                                {
#pragma warning disable CS8625
                                    throw new InconsistentEnumException(
                                        enumType.Name, 
                                        nameof(matchingEnum.Id),
                                        null,
                                        enumValue.Id.ToString()
                                    );
#pragma warning restore CS8625
                                }
                            }
                            else
                            {
                                throw new MissingBaseClassException(enumType.Name);
                            }
                        }
                        else
                        {
#pragma warning disable CS8625
                            throw new InconsistentEnumException(
                                enumType.Name, 
                                nameof(element.Name), 
                                null, 
                                element.Name
                            );
#pragma warning restore CS8625
                        }
                    }
                }
                else
                {
                    throw new MissingInterfaceException(dbSetType.Name);
                }
            }
        }
        else
        {
            throw new AssemblyNotFoundException(typeof(TypeSafeEnum<>).Name, nameof(EnsureTypeSafeEnumValidation));
        }
    }
}