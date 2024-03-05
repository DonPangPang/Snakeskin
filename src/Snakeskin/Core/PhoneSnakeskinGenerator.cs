using System.Text;

namespace Snakeskin.Core;

public class PhoneSnakeskinGenerator : IPhoneSnakeskinGenerator
{
    protected readonly string _chars = "0123456789";
    protected readonly Random _random = new();

    public virtual string GenerateTelephoneNumber()
    {
        var result = new StringBuilder();
        result.Append("0"); // Add the country code
        for (var i = 0; i < 10; i++)
        {
            var index = _random.Next(0, _chars.Length);
            var c = _chars[index];
            result.Append(c);
        }

        return result.ToString();
    }

    public virtual string GeneratePhoneNumber(CountryCode? countryCode = null, int length = 11)
    {
        return GeneratePhoneNumber(countryCode, length);
    }

    public virtual string GeneratePhoneNumber(int? countryCode = null, int length = 11)
    {
        var result = new StringBuilder();
        if (countryCode.HasValue) result.Append($"+{countryCode.Value}");
        result.Append(1);
        for (var i = 0; i < length - 1; i++)
        {
            var index = _random.Next(0, _chars.Length);
            var c = _chars[index];
            result.Append(c);
        }

        return result.ToString();
    }
}
