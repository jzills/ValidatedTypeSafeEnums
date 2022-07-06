using Microsoft.EntityFrameworkCore;

namespace ValidatedTypeSafeEnums.Data;

#pragma warning disable CS8618

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options) {}

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
    public virtual DbSet<OrderShippingStatus> OrderShippingStatuses { get; set; }
    public virtual DbSet<OrderType> OrderTypes { get; set; }
    public virtual DbSet<OrderPaymentMethodType> OrderPaymentMethodTypes { get; set; }
    public virtual DbSet<OrderPaymentCycle> OrderPaymentCycles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<OrderStatus>()
            .HasData(new OrderStatus[]
            {
                new OrderStatus { Id = 1, Name = "Pending" },
                new OrderStatus { Id = 2, Name = "Purchased" },
                new OrderStatus { Id = 3, Name = "Received" } 
            });

        modelBuilder
            .Entity<OrderShippingStatus>()
            .HasData(new OrderShippingStatus[]
            {
                new OrderShippingStatus { Id = 1, Name = "Shipping Label Created" },
                new OrderShippingStatus { Id = 2, Name = "Awaiting Pickup" },
                new OrderShippingStatus { Id = 3, Name = "In Transit" },
                new OrderShippingStatus { Id = 4, Name = "Delivered" } 
            });

        modelBuilder
            .Entity<OrderType>()
            .HasData(new OrderType[]
            {
                new OrderType { Id = 1, Name = "In Store" },
                new OrderType { Id = 2, Name = "Pickup" },
                new OrderType { Id = 3, Name = "Online" } 
            });

        modelBuilder
            .Entity<OrderPaymentMethodType>()
            .HasData(new OrderPaymentMethodType[]
            {
                new OrderPaymentMethodType { Id = 1, Name = "Credit" },
                new OrderPaymentMethodType { Id = 2, Name = "Debit" },
                new OrderPaymentMethodType { Id = 3, Name = "Check" } 
            });

        modelBuilder
            .Entity<OrderPaymentCycle>()
            .HasData(new OrderPaymentCycle[]
            {
                new OrderPaymentCycle { Id = 1, Name = "1 Month" },
                new OrderPaymentCycle { Id = 2, Name = "3 Months" },
                new OrderPaymentCycle { Id = 3, Name = "6 Months" },
                new OrderPaymentCycle { Id = 4, Name = "1 Year" } 
            });
    }
}
