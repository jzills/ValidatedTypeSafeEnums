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