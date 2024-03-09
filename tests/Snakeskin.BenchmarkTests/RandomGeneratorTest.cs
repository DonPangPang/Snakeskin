using BenchmarkDotNet.Attributes;
using Snakeskin.Core;

namespace Snakeskin.BenchmarkTests;

public class RandomGeneratorTest
{
    [Benchmark]
    public void GeneralRandomTest()
    {
        var value = SnakeskinGenerator.RandomNumber(1, 100);
    }


    [Benchmark]
    public void QuickRandomTest()
    {
        var value = SnakeskinGenerator.QuickRandom(2);
    }
}
