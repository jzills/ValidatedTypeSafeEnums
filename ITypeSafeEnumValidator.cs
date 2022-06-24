namespace ValidatedTypeSafeEnums;

public interface ITypeSafeEnumValidator<T>
{
    void EnsureTypeSafeEnumValidation();
}