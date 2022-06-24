using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ValidatedTypeSafeEnums.Data;
using ValidatedTypeSafeEnums.Exceptions;
using ValidatedTypeSafeEnums.Extensions;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums;

public interface IEnumValidator
{
    public void EnsureTypeSafeEnumValidation();
}

public class EnumValidator : IEnumValidator
{
    private readonly ApplicationDbContext _context; 

    public EnumValidator(ApplicationDbContext context) => _context = context;

    public void EnsureTypeSafeEnumValidation()
    {
        var assembly = Assembly.GetAssembly(typeof(TypeSafeEnum<>));
        if (assembly != null)
        {
            var dbSetTypes = _context.GetDbSetTypes();
            var enumTypes = assembly.GetTypes().Where(type => type.IsTypeSafeEnum());
            foreach (var enumType in enumTypes)
            {
                var enumName = enumType.Name.Substring(0, enumType.Name.IndexOf("Enum"));
                var dbSetType = dbSetTypes.First(type => type.Name == enumName);
                var dbSet = _context.Set(dbSetType) as IQueryable<ITypeSafeEnum>;
                if (dbSet != null)
                {
                    foreach (var element in dbSet)
                    {
                        var enumField = enumType.GetField(element.Name, BindingFlags.Public | BindingFlags.Static);
                        if (enumField != null)
                        {
                            var enumValue = enumField.GetValue(null) as TypeSafeEnumBase;
                            if (enumValue != null)
                            {
                                var matchingEnum = dbSet.FirstOrDefault(element => element.Id == enumValue.Id);
                                if (matchingEnum == null)
                                {
                                    throw new Exception(
                                        $"The enum {enumType.Name} has an incorrect value" + 
                                        $" for the field Id");
                                }
                            }
                            else
                            {
                                throw new MissingBaseClassException(
                                    $"The enum {enumType.Name} is missing a" + 
                                    $" base class of {nameof(TypeSafeEnumBase)}"
                                );
                            }
                        }
                        else
                        {
                            throw new MissingFieldException(
                                $"The enum {enumType.Name} is missing a" + 
                                $" field for the database record {element.Name}"
                            );
                        }
                    }
                }
                else
                {
                    throw new MissingInterfaceException(
                        $"DbSet for {dbSetType.Name} couldn't" +
                        $" be found or is not inheriting from {nameof(ITypeSafeEnum)}"
                    );
                }
            }
        }
        else
        {
            throw new AssemblyNotFoundException(
                $"Assembly not found for {typeof(TypeSafeEnum<>).Name} " +
                $"in calling method {nameof(EnsureTypeSafeEnumValidation)}"
            );
        }
    }
}