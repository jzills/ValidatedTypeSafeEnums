namespace Source.Exceptions;

public class EnumNotFoundException : Exception
{
    private const string _message = "No mapping found for the enum type \"{0}\" to the field \"{1}\".";

    public EnumNotFoundException(string enumTypeName, string enumMap)
        : base(string.Format(_message, enumTypeName, enumMap))
    {
    }
}