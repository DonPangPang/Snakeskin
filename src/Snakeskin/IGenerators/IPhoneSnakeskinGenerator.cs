using Snakeskin.Enums;

namespace Snakeskin.IGenerators;

public interface IPhoneSnakeskinGenerator : ISnakeskinGenerator
{
    string GeneratePhoneNumber(CountryCode? countryCode = null, int length = 11);

    string GeneratePhoneNumber(int? countryCode = null, int length = 11);

    string GenerateTelephoneNumber();
}