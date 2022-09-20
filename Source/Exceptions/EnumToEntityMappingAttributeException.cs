using Source.TypeSafeEnums;

namespace Source.Exceptions;

public class EnumToEntityMappingAttributeException : Exception
{
    private const string _message = "The class \"{0}\" must have the required attribute "
        + "\"{1}\" for the field that maps to the respective entity properties on exactly one field.";

    public EnumToEntityMappingAttributeException()
        : base(string.Format(_message, nameof(TypeSafeEnumBase), nameof(EnumToEntityMappingAttribute)))
    {
    }
}