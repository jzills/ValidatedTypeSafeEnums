using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Exceptions;

public class MissingBaseClassException : Exception
{
    private const string _message = "The type safe enum {0} is not derived from the base class {1}.";

    public MissingBaseClassException(string? typeName)
        : base(string.Format(_message, typeName, nameof(TypeSafeEnumBase)))
    {        
    }
}