using Microsoft.EntityFrameworkCore;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Role> Roles { get; set; }
}
