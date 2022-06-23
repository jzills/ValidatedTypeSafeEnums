using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ValidatedTypeSafeEnums.TypeSafeEnums;

#pragma warning disable CS8600, CS8619

public sealed class RoleEnum
{
    public static RoleEnum User             = new RoleEnum(1, nameof(User), "This role allows basic permissions.");
    public static RoleEnum Manager          = new RoleEnum(2, nameof(Manager), "This role allows elevated permissions to manage other users.");
    public static RoleEnum Administrator    = new RoleEnum(3, nameof(Administrator), "This role allows the highest level of permissions.");

    private RoleEnum(int id, string name, string description) =>
        (Id, Name, Description) = (id, name, description);

    public readonly int Id;
    public readonly string Name;
    public readonly string Description;

    public static List<RoleEnum> GetRoles() =>
        typeof(RoleEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(field => (RoleEnum)field.GetValue(null))
            .ToList();
}