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

var validator = serviceProvider.GetRequiredService<IEnumValidator>();
validator.EnsureTypeSafeEnumValidation();
// var enums = RoleEnum.GetValues();
// var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
// var dbSetTypes = context.GetDbSetTypes();
// var debug = dbSetTypes;

// var properties = typeof(ApplicationDbContext)
//     .GetProperties(BindingFlags.Public | BindingFlags.Instance)
//     .Where(property => property.PropertyType.IsGenericType && typeof(DbSet<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
//     .Select(property => property.PropertyType.GetGenericTypeDefinition());

// var a = Assembly.GetAssembly(typeof(TypeSafeEnum<>)).GetTypes().Where(type => type.IsTypeSafeEnum());
//https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class
//var enums = new string[] { "RoleEnum" }; // TODO: Dynamically fetch enum


// foreach (var role in RoleEnum.GetRoles())
//     Console.WriteLine(role.Name);

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