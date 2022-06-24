namespace ValidatedTypeSafeEnums.Exceptions;

public class AssemblyNotFoundException : Exception
{
    public AssemblyNotFoundException(string? message) : base(message)
    {
    }
}