using Microsoft.Extensions.DependencyInjection;
using Snakeskin.Core;
using Snakeskin.Generators;
using Snakeskin.IGenerators;
using System.Text.Json;

namespace Snakeskin;

public static class SnakeskinExtensions
{
    public static IServiceCollection AddSnakeskin(this IServiceCollection services)
    {
        SnakeskinBuilder.Build();

        services.AddSnakeskinPrivate();

        return services;
    }

    internal static IServiceCollection AddSnakeskinPrivate(this IServiceCollection services)
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

public static class SnakeskinConfiguration
{
    private static Dictionary<string, List<object>>? _seed { get; set; } = null;

    static SnakeskinConfiguration()
    {
        if (_seed is not null) return;

        _seed ??= [];

        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "snakeskin.json");

        if (File.Exists(file))
        {
            var json = File.ReadAllText(file);
            var config = JsonSerializer.Deserialize<Dictionary<string, List<object>>>(json);

            if (config != null)
            {
                _seed = config;
            }
        }
        else
        {
            File.WriteAllText(file, "{}");
        }
    }

    public static IEnumerable<object> GetSeed(string key)
    {
        if (_seed?.TryGetValue(key, out var value) ?? false)
        {
            return value;
        }

        return Enumerable.Empty<object>();
    }

    public static Dictionary<string, List<object>> GetSeeds()
    {
        return _seed ?? [];
    }
}