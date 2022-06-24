namespace ValidatedTypeSafeEnums.Exceptions;

public class InconsistentEnumException : Exception
{
    private const string _message = "The enum \"{0}\" has an incorrect or missing value for the field \"{1}\". " + 
        "Expected the value \"{2}\" but found \"{3}\".";

    public InconsistentEnumException(string enumTypeName, string name, string value, string expectedValue)
        : base(string.Format(_message, enumTypeName, name, expectedValue, value))
    {
    }
}