using BenchmarkDotNet.Attributes;
using Snakeskin.Enums;

namespace Snakeskin.BenchmarkTests;

public class SnakeskinTest
{
    [Benchmark]
    public void GeneratorBoolean()
    {
        var value = Snakeskin.Boolean();
    }

    [Benchmark]
    public void GeneratorBooleanProbability()
    {
        var value = Snakeskin.Boolean(0.7f);
    }

    [Benchmark]
    public void GeneratorDateTime()
    {
        var value = Snakeskin.DateTime();
    }

    [Benchmark]
    public void GeneratorDateTimeInterval()
    {
        var value = Snakeskin.DateTime(DateTime.MinValue, DateTime.MaxValue);
    }

    [Benchmark]
    public void GeneratorGuid()
    {
        var value = Snakeskin.Guid();
    }

    [Benchmark]
    public void GeneratorGuidOrdered()
    {
        var value = Snakeskin.Guid(true);
    }

    [Benchmark]
    public void GeneratorInt()
    {
        var value = Snakeskin.Int();
    }

    [Benchmark]
    public void GeneratorIntInterval()
    {
        var value = Snakeskin.Int(0, 1000);
    }

    [Benchmark]
    public void GeneratorFloat()
    {
        var value = Snakeskin.Float();
    }

    [Benchmark]
    public void GeneratorFloatInterval()
    {
        var value = Snakeskin.Float(0, 1000);
    }

    [Benchmark]
    public void GeneratorString()
    {
        var value = Snakeskin.String();
    }

    [Benchmark]
    public void GeneratorStringFixLenght()
    {
        var value = Snakeskin.String(16);
    }

    [Benchmark]
    public void GeneratorStringInterval()
    {
        var value = Snakeskin.String(10, 20);
    }

    [Benchmark]
    public void GeneratorName()
    {
        var value = Snakeskin.Name();
    }

    [Benchmark]
    public void GeneratorPhone()
    {
        var value = Snakeskin.Phone();
    }

    [Benchmark]
    public void GeneratorPhoneWithCountryCode()
    {
        var value = Snakeskin.Phone(CountryCode.China);
    }

    [Benchmark]
    public void GeneratorPhoneWithCountryCodeNumber()
    {
        var value = Snakeskin.PhoneV2(86);
    }

    [Benchmark]
    public void GeneratorTelephone()
    {
        var value = Snakeskin.Telephone();
    }
}