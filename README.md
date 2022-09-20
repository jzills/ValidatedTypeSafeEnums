# Validated Type Safe Enums

## TL;DR
Avoid extra database hits for LUT values with a code copy TypeSafeEnum but ensure consistency by validating during application startup.

## Summary
It's convenient to maintain classes using the TypeSafeEnum pattern to avoid having to call the database everytime you need an id or a label for a LUT. The biggest downside is ensuring that consistency is kept between the database values and the values in the codebase. It's easy for changes to be made on one end and miss communicating the change on the other. So, validate them when your application starts and uncover any discrepensies before accidents happen.

## Additional Resources
[Smart enums / Type-safe enums in .NET](https://www.meziantou.net/smart-enums-type-safe-enums-in-dotnet.htm)

[How to implement a type-safe enum pattern in C#](https://www.infoworld.com/article/3198453/how-to-implement-a-type-safe-enum-pattern-in-c.html#:~:text=The%20strongly%20typed%20enum%20pattern%20or%20the%20type%2Dsafe%20enum,it%20much%20like%20an%20enum.)
