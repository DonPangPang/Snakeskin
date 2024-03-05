using System.Text;

namespace Snakeskin.Core;

public class UsernameSnakeskinGenerator : StringSnakeskinGenerator, IUsernameSnakeskinGenerator
{
    public override string Generate()
    {
        var length = _random.Next(5, 20);
        return Generator(length);
    }

    public override string Generator(int length, string? chars = null, bool lowerCase = false)
    {
        var charArray = (chars ?? _chars).ToCharArray();
        var result = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            var index = _random.Next(0, charArray.Length);
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

    public override string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minLength);

        var length = _random.Next(minLength, maxLength);
        return Generator(length, chars, lowerCase);   
    }
}
