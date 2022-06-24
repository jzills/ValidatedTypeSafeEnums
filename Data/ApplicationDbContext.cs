using Microsoft.EntityFrameworkCore;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options) {}

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Role>()
            .HasData(new Role[]
            {
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Administrator" } 
            });
    }
}
