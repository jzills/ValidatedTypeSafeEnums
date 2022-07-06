namespace ValidatedTypeSafeEnums.Validation;

public interface ITypeSafeEnumValidator<T>
{
    void EnsureTypeSafeEnumValidation();
}