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
                new OrderStatus { Id = 1, Label = "Pending" },
                new OrderStatus { Id = 2, Label = "Purchased" },
                new OrderStatus { Id = 3, Label = "Received" } 
            });

        modelBuilder
            .Entity<OrderShippingStatus>()
            .HasData(new OrderShippingStatus[]
            {
                new OrderShippingStatus { Id = 1, Label = "Shipping Label Created" },
                new OrderShippingStatus { Id = 2, Label = "Awaiting Pickup" },
                new OrderShippingStatus { Id = 3, Label = "In Transit" },
                new OrderShippingStatus { Id = 4, Label = "Delivered" } 
            });

        modelBuilder
            .Entity<OrderType>()
            .HasData(new OrderType[]
            {
                new OrderType { Id = 1, Label = "In Store" },
                new OrderType { Id = 2, Label = "Pickup" },
                new OrderType { Id = 3, Label = "Online" } 
            });

        modelBuilder
            .Entity<OrderPaymentMethodType>()
            .HasData(new OrderPaymentMethodType[]
            {
                new OrderPaymentMethodType { Id = 1, Label = "Credit" },
                new OrderPaymentMethodType { Id = 2, Label = "Debit" },
                new OrderPaymentMethodType { Id = 3, Label = "Check" } 
            });

        modelBuilder
            .Entity<OrderPaymentCycle>()
            .HasData(new OrderPaymentCycle[]
            {
                new OrderPaymentCycle { Id = 1, Label = "1 Month" },
                new OrderPaymentCycle { Id = 2, Label = "3 Months" },
                new OrderPaymentCycle { Id = 3, Label = "6 Months" },
                new OrderPaymentCycle { Id = 4, Label = "1 Year" } 
            });

        modelBuilder
            .Entity<Order>()
            .HasData(new Order[]
            {
                new Order 
                { 
                    Id = 1, 
                    OrderPaymentCycleId = 1,
                    OrderPaymentMethodTypeId = 1,
                    OrderShippingStatusId = 1,
                    OrderStatusId = 1,
                    OrderTypeId = 1,
                    PlacedOn = DateTime.Now
                },
                new Order 
                { 
                    Id = 2, 
                    OrderPaymentCycleId = 2,
                    OrderPaymentMethodTypeId = 2,
                    OrderShippingStatusId = 2,
                    OrderStatusId = 2,
                    OrderTypeId = 2,
                    PlacedOn = DateTime.Now
                }
            });
    }
}
