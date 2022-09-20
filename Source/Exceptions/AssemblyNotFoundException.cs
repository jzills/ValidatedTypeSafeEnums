using Source.TypeSafeEnums;

namespace Source.Exceptions;

public class AssemblyNotFoundException : Exception
{
    private const string _message = "Assembly not found for {0} in calling method {1}.";

    public AssemblyNotFoundException(string typeName, string callingMethodName)
        : base(string.Format(_message, typeName, callingMethodName))
    {
    }
}