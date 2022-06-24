using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ValidatedTypeSafeEnums.TypeSafeEnums;

#pragma warning disable CS8600, CS8619

public sealed class RoleEnum : TypeSafeEnum<RoleEnum>, ITypeSafeEnum
{
    public static RoleEnum User             = new RoleEnum(1, nameof(User), "This role allows basic permissions.");
    public static RoleEnum Manager          = new RoleEnum(2, nameof(Manager), "This role allows elevated permissions to manage other users.");
    public static RoleEnum Administrator    = new RoleEnum(3, nameof(Administrator), "This role allows the highest level of permissions.");

    private RoleEnum(int id, string name, string description)
        : base(id, name) => Description = description;

    public readonly string Description;
}