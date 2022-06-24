using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ValidatedTypeSafeEnums;
using ValidatedTypeSafeEnums.Data;
using ValidatedTypeSafeEnums.Extensions;
using ValidatedTypeSafeEnums.TypeSafeEnums;

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(nameof(ApplicationDbContext)))
    .AddScoped<IEnumValidator, EnumValidator>()
    .BuildServiceProvider();

// Ensure crea
var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

var validator = serviceProvider.GetRequiredService<IEnumValidator>();
validator.EnsureTypeSafeEnumValidation();
Console.WriteLine("Valid!");

// var value = Role.Administrator;
// switch (value)
// {
//     case var _ when value == Role.User:
//         Console.WriteLine("I am a user.");
//         break;
//     case var _ when value == Role.Manager:
//         Console.WriteLine("I am a manager.");
//         break;
//     case var _ when value == Role.Administrator:
//         Console.WriteLine("I am a administrator.");
//         break;
// }