using Snakeskin.Core;
using Snakeskin.Enums;
using Snakeskin.IGenerators;

namespace Snakeskin;

public static class Snakeskin
{
    public static bool Boolean() => SnakeskinBuilder.GetService<IBooleanSnakeskinGenerator>().Generate();

    public static bool Boolean(float trueProbability) => SnakeskinBuilder.GetService<IBooleanSnakeskinGenerator>().Generate(trueProbability);

    public static DateTime DateTime() => SnakeskinBuilder.GetService<IDateTimeSnakeskinGenerator>().Generate();

    public static DateTime DateTime(DateTime min, DateTime max) => SnakeskinBuilder.GetService<IDateTimeSnakeskinGenerator>().Generate(min, max);

    public static Guid Guid() => Guid(true);

    public static Guid Guid(bool ordered = false) => SnakeskinBuilder.GetService<IGuidSnakeskinGenerator>().Generate(ordered);

    public static int Int() => Int(0, 100);

    public static int Int(int min = 0, int max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateInt(min, max);

    public static float Float() => Float(0, 100);

    public static float Float(float min = 0, float max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateFloat(min, max);

    public static double Double() => Double(0, 100);

    public static double Double(double min = 0, double max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateDouble(min, max);

    public static decimal Decimal() => Decimal(0, 100);

    public static decimal Decimal(decimal min = 0, decimal max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateDecimal(min, max);

    public static string String() => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generate();

    public static string String(int length, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generator(length, chars, lowerCase);

    public static string String(int minLength, int maxLength, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generator(minLength, maxLength, chars, lowerCase);

    public static string Name() => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generate();

    public static string Name(int length, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generator(length, chars, lowerCase);

    public static string Name(int minLength, int maxLength, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generator(minLength, maxLength, chars, lowerCase);

    public static string Phone() => Phone(null);

    public static string Phone(CountryCode? countryCode = null, int length = 11) => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GeneratePhoneNumber(countryCode, length);

    public static string PhoneV2(int? countryCode = null, int length = 11) => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GeneratePhoneNumber(countryCode, length);

    public static string Telephone() => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GenerateTelephoneNumber();

    public static string Address() => SnakeskinBuilder.GetService<IAddressSnakeskinGenerator>().Generate();
    public static string Address_City() => SnakeskinBuilder.GetService<IAddressSnakeskinGenerator>().GenerateCity();
    public static string Address_Street() => SnakeskinBuilder.GetService<IAddressSnakeskinGenerator>().GenerateStreet();
    public static string Address_County() => SnakeskinBuilder.GetService<IAddressSnakeskinGenerator>().GenerateCounty();
    public static string Address_HouseNumber() => SnakeskinBuilder.GetService<IAddressSnakeskinGenerator>().GenerateHouseNumber();
}