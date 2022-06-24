using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class Role : ITypeSafeEnum
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}