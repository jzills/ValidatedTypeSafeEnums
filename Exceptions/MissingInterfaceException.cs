using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Exceptions;

public class MissingInterfaceException : Exception
{
    private const string _message = "Type for {0} couldn't be found or is not inheriting from {1}";
    
    public MissingInterfaceException(string? typeName) 
        : base(string.Format(_message, typeName, nameof(ITypeSafeEnum)))
    {
    }
}