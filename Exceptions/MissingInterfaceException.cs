namespace ValidatedTypeSafeEnums.Exceptions;

public class MissingInterfaceException : Exception
{
    public MissingInterfaceException(string? message) : base(message)
    {
    }
}