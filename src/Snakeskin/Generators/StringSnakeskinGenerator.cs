using Snakeskin.Core;
using Snakeskin.IGenerators;
using System.Text;

namespace Snakeskin.Generators;

public class StringSnakeskinGenerator : IStringSnakeskinGenerator
{
    protected readonly string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    public string Generate()
    {
        var length = SnakeskinGenerator.RandomNumber(1, 100);
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

        return result.ToString();
    }

    public string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minLength);

        var length = SnakeskinGenerator.RandomNumber(minLength, maxLength);
        return Generator(length, chars, lowerCase);
    }
}