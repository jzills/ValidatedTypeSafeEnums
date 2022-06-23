using ValidatedTypeSafeEnums.Data;
using ValidatedTypeSafeEnums.TypeSafeEnums;

using var context = new ApplicationDbContext();
var roles = RoleEnum.GetRoles();
var debug = roles;
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