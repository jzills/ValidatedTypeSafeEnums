namespace ValidatedTypeSafeEnums.Exceptions;

public class MissingBaseClassException : Exception
{
    public MissingBaseClassException(string? message) : base(message)
    {
    }
}