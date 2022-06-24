namespace ValidatedTypeSafeEnums.Exceptions;

public class AssemblyNotFound : Exception
{
    public AssemblyNotFound(string? message) : base(message)
    {
    }
}