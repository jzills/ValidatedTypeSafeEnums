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
                var debug = dbSetType;
            }
        }
        else
        {
            throw new AssemblyNotFound(
                $"Assembly not found for {typeof(TypeSafeEnum<>).Name} " +
                $"in calling method {nameof(EnsureTypeSafeEnumValidation)}"
            );
        }
    }
}