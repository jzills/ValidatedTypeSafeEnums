using System.Text.RegularExpressions;
using ValidatedTypeSafeEnums.TypeSafeEnums;

namespace ValidatedTypeSafeEnums.Extensions;

public static class TypeSafeEnumExtensions
{
    private static readonly Regex _regexNumber = new Regex("[0-9]");
    private static readonly Regex _regexIdentifier = new Regex("[^a-zA-Z0-9_]");

    public static string CleanName(this ITypeSafeEnum source)
    {
        var replace = _regexIdentifier.Replace(source.Name, string.Empty);
        if (replace.Length > 0 && char.IsDigit(replace[0]))
        {
            var match = _regexNumber.Match(replace);
            if (match.Success)
            {   
                replace = $"{replace.Remove(match.Index, match.Length)}{match.Value}";
            }
        }

        return replace;
    }
}