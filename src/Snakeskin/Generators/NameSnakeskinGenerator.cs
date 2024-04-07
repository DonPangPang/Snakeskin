using Snakeskin.Core;
using Snakeskin.IGenerators;
using System.Text;

namespace Snakeskin.Generators;

public class NameSnakeskinGenerator : INameSnakeskinGenerator
{
    protected readonly string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private readonly string _firstName = "Fake";
    private readonly string _secondName = "Name";

    public string Generate(int extract = 16)
    {
        var rand = DateTime.UtcNow.Ticks;
        var randString = rand.ToString().Substring(rand.ToString().Length - 2);
        return $"{_firstName}{SnakeskinGenerator.ExtractRandom(extract)} {_secondName}{SnakeskinGenerator.ExtractRandom(2)}";
    }

    [Obsolete]
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

    [Obsolete]
    public string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minLength);

        var length = SnakeskinGenerator.RandomNumber(minLength, maxLength);
        return Generator(length, chars, lowerCase);
    }
}