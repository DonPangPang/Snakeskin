using System.Text;
using Snakeskin.Core;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class NameSnakeskinGenerator : INameSnakeskinGenerator
{
    protected readonly string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public string Generate()
    {
        var length = SnakeskinGenerator.RandomNumber(5, 20);
        return Generator(length);
    }

    public string Generator(int length, string? chars = null, bool lowerCase = false)
    {
        var charArray = (chars ?? _chars).ToCharArray();
        var result = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            var index = SnakeskinGenerator.RandomNumber(0, charArray.Length);
            var c = charArray[index];
            if (lowerCase && char.IsLetter(c))
            {
                c = char.ToLower(c);
            }
            result.Append(c);
        }

        var generatedName = result.ToString();
        if (!lowerCase)
        {
            generatedName = char.ToUpper(generatedName[0]) + generatedName.Substring(1).ToLower();
        }

        return generatedName;
    }

    public string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minLength);

        var length = SnakeskinGenerator.RandomNumber(minLength, maxLength);
        return Generator(length, chars, lowerCase);
    }
}
