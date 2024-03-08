using Microsoft.Extensions.DependencyInjection;
using Snakeskin.Core;
using Snakeskin.Enums;
using Snakeskin.Generators;
using Snakeskin.IGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakeskin;

public static class SnakeskinExtensions
{
    public static IServiceCollection AddSnakeskin(this IServiceCollection services)
    {
        SnakeskinBuilder.Build();

        services.AddSnakeskinPrivate();

        return services;
    }

    public static IServiceCollection AddSnakeskinPrivate(this IServiceCollection services)
    {
        services.AddSingleton<IBooleanSnakeskinGenerator, BooleanSnakeskinGenerator>();
        services.AddSingleton<IDateTimeSnakeskinGenerator, DateTimeSnakeskinGenerator>();
        services.AddSingleton<IGuidSnakeskinGenerator, GuidSnakeskinGenerator>();
        services.AddSingleton<INumberSnakeskinGenerator, NumberSnakeskinGenerator>();
        services.AddSingleton<IStringSnakeskinGenerator, StringSnakeskinGenerator>();
        services.AddSingleton<INameSnakeskinGenerator, NameSnakeskinGenerator>();
        services.AddSingleton<IPhoneSnakeskinGenerator, PhoneSnakeskinGenerator>();

        return services;
    }
}

public static class Snakeskin
{
    public static bool Boolean() => SnakeskinBuilder.GetService<IBooleanSnakeskinGenerator>().Generate();
    public static bool Boolean(float trueProbability) => SnakeskinBuilder.GetService<IBooleanSnakeskinGenerator>().Generate(trueProbability);
    public static DateTime DateTime() => SnakeskinBuilder.GetService<IDateTimeSnakeskinGenerator>().Generate();
    public static DateTime DateTime(DateTime min, DateTime max) => SnakeskinBuilder.GetService<IDateTimeSnakeskinGenerator>().Generate(min, max);
    public static Guid Guid(bool ordered = false) => SnakeskinBuilder.GetService<IGuidSnakeskinGenerator>().Generate(ordered);
    public static int Int(int min = 0, int max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateInt(min, max);
    public static float Float(float min = 0, float max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateFloat(min, max);
    public static double Double(double min = 0, double max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateDouble(min, max);
    public static decimal Decimal(decimal min = 0, decimal max = 100) => SnakeskinBuilder.GetService<INumberSnakeskinGenerator>().GenerateDecimal(min, max);
    public static string String() => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generate();
    public static string String(int length, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generator(length, chars, lowerCase);
    public static string String(int minLength, int maxLength, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<IStringSnakeskinGenerator>().Generator(minLength, maxLength, chars, lowerCase);
    public static string Name() => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generate();
    public static string Name(int length, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generator(length, chars, lowerCase);
    public static string Name(int minLength, int maxLength, string? chars = null, bool lowerCase = false) => SnakeskinBuilder.GetService<INameSnakeskinGenerator>().Generator(minLength, maxLength, chars, lowerCase);
    public static string Phone(CountryCode? countryCode = null, int length = 11) => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GeneratePhoneNumber(countryCode, length);
    public static string PhoneV2(int? countryCode = null, int length = 11) => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GeneratePhoneNumber(countryCode, length);
    public static string Telephone() => SnakeskinBuilder.GetService<IPhoneSnakeskinGenerator>().GenerateTelephoneNumber();

}
