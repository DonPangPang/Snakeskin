using System.Text;
using Snakeskin.Core;
using Snakeskin.Enums;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class PhoneSnakeskinGenerator : IPhoneSnakeskinGenerator
{
    protected readonly string _chars = "0123456789";
    public string GenerateTelephoneNumber()
    {
        var result = new StringBuilder();
        result.Append("0"); // Add the country code
        for (var i = 0; i < 10; i++)
        {
            var index = SnakeskinGenerator.RandomNumber(0, _chars.Length);
            var c = _chars[index];
            result.Append(c);
        }

        return result.ToString();
    }

    public string GeneratePhoneNumber(CountryCode? countryCode = null, int length = 11)
    {
        return GeneratePhoneNumber(countryCode, length);
    }

    public string GeneratePhoneNumber(int? countryCode = null, int length = 11)
    {
        var result = new StringBuilder();
        if (countryCode.HasValue) result.Append($"+{countryCode.Value}");
        result.Append(1);
        for (var i = 0; i < length - 1; i++)
        {
            var index = SnakeskinGenerator.RandomNumber(0, _chars.Length);
            var c = _chars[index];
            result.Append(c);
        }

        return result.ToString();
    }
}
