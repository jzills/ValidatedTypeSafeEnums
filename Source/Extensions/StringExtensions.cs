using System.Text.RegularExpressions;

namespace Source.Extensions;

public static class StringEnumExtensions
{
    private static readonly Regex _regexNumber = new Regex("[0-9]");
    private static readonly Regex _regexIdentifier = new Regex("[^a-zA-Z0-9_]");

    public static string Clean(this string source)
    {
        var replace = _regexIdentifier.Replace(source, string.Empty);
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