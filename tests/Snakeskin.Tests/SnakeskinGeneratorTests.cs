using Snakeskin.Core;
using Xunit.Abstractions;

namespace Snakeskin.Tests;

public class SnakeskinGeneratorTests
{
    private readonly ITestOutputHelper _output;

    public SnakeskinGeneratorTests(ITestOutputHelper output)
    {
        _output = output;
    }

    private static long _seed = Environment.TickCount;

    public static int QuickRandom(int length)
    {
        _seed = (_seed * 0x5DEECE66DL + 0xB) & ((1L << 48) - 1);
        return (int)((_seed >> (48 - length)) % Math.Pow(10, length));
    }

    [Fact]
    public void GeneratorQuickRandom()
    {
        for (int i = 0; i < 100; i++)
        {
            var value = SnakeskinGenerator.QuickRandomNumber(2);

            _output.WriteLine(value.ToString());
        }
    }
}
