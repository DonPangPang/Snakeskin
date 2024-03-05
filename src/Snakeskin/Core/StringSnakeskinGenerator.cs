using System.Text;

namespace Snakeskin.Core;

public abstract class StringSnakeskinGenerator: IStringSnakeskinGenerator
{
    protected readonly string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    protected readonly Random _random = new Random();
    public virtual string Generate()
    {
        var length = _random.Next(1, 100);
        return Generator(length);
    }

    public virtual string Generator(int length, string? chars = null, bool lowerCase = false)
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

        return result.ToString();
    }

    public virtual string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minLength);

        var length = _random.Next(minLength, maxLength);
        return Generator(length, chars, lowerCase);
    }
}
