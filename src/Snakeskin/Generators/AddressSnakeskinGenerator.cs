using Snakeskin.Core;
using Snakeskin.IGenerators;
using System.Collections.Concurrent;
using System.Text;

namespace Snakeskin.Generators;

public class AddressSnakeskinGenerator : IAddressSnakeskinGenerator
{
    private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";
    public string Generate(AddressType addressType = AddressType.Full)
    {
        var sb = new StringBuilder();
        if (addressType.HasFlag(AddressType.County))
        {
            sb.Append(GenerateCounty());
        }
        if (addressType.HasFlag(AddressType.City))
        {
            sb.Append($" {GenerateCity()}");
        }
        if (addressType.HasFlag(AddressType.Street))
        {
            sb.Append($" {GenerateStreet()}");
        }
        if (addressType.HasFlag(AddressType.HouseNumber))
        {
            sb.Append($" {GenerateHouseNumber()}");
        }
        return sb.ToString();
    }

    private static int _maxCountyCacheLength = 100;
    private static int _maxCityCacheLength = 200;
    private static int _maxStreetCacheLength = 500;
    private static int _maxHouseNumberCacheLength = 1000;
    private readonly string[] _countyCache = new string[_maxCountyCacheLength];
    private readonly string[] _cityCache = new string[_maxCityCacheLength];
    private readonly string[] _streetCache = new string[_maxStreetCacheLength];
    private readonly string[] _houseNumberCache = new string[_maxHouseNumberCacheLength];


    public string GenerateCounty()
    {
        try
        {
            if (_maxCountyCacheLength <= 0)
            {
                return _countyCache[SnakeskinGenerator.QuickRandomNumber(0, _maxCountyCacheLength)];
            }

            var county = Snakeskin.String(10);
            _countyCache[--_maxCountyCacheLength] = county;
            return county;
        }
        catch { return "Unknown County"; }
    }

    public string GenerateCity()
    {
        try
        {
            if (_maxCityCacheLength <= 0)
            {
                return _cityCache[SnakeskinGenerator.QuickRandomNumber(0, _maxCityCacheLength)];
            }

            var city = Snakeskin.String(10);
            _cityCache[--_maxCityCacheLength] = city;
            return city;
        }
        catch { return "Unknown City"; }
    }


    public string GenerateStreet()
    {
        try
        {
            if (_maxStreetCacheLength <= 0)
            {
                return _streetCache[SnakeskinGenerator.QuickRandomNumber(0, _maxStreetCacheLength)];
            }

            var street = Snakeskin.String(10);
            _streetCache[--_maxStreetCacheLength] = street;
            return street;
        }
        catch { return "Unknown Street"; }
    }
    public string GenerateHouseNumber()
    {
        try
        {
            return $"No.{SnakeskinGenerator.QuickRandomNumber(0, _maxHouseNumberCacheLength)}";
        }
        catch { return "Unknown House Number"; }
    }
}
