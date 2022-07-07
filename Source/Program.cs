using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ValidatedTypeSafeEnums.Data;
using ValidatedTypeSafeEnums.Enums;
using ValidatedTypeSafeEnums.Validation;

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(nameof(ApplicationDbContext)))
    .AddScoped(typeof(ITypeSafeEnumValidator<>), typeof(TypeSafeEnumValidator<>))
    .BuildServiceProvider();

var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

var validator = serviceProvider.GetRequiredService<ITypeSafeEnumValidator<ApplicationDbContext>>();
validator.EnsureTypeSafeEnumValidation();

var orderPaymentCycles = OrderPaymentCycleEnum.GetValues();
foreach (var orderPaymentCycle in orderPaymentCycles)
{
    Console.WriteLine($"Id: {orderPaymentCycle.Id}\nLabel: {orderPaymentCycle.Label}");
}

int orderTypeId = OrderTypeEnum.InStore;
string orderTypeLabel = OrderTypeEnum.InStore;
Console.WriteLine($"Id: {orderTypeId}\nLabel: {orderTypeLabel}");

var (orderStatusId, orderStatusLabel) = OrderStatusEnum.Purchased;
Console.WriteLine($"Id: {orderStatusId}\nLabel: {orderStatusLabel}");