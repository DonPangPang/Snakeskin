using Snakeskin.Core;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class DateTimeSnakeskinGenerator : IDateTimeSnakeskinGenerator
{
    public DateTime Generate(DateTime min, DateTime max)
    {
        var range = (max - min).Days;
        return min.AddDays(SnakeskinGenerator.RandomNumber(0, range));
    }

    public DateTime Generate()
    {
        var range = 30;
        return DateTime.UtcNow.AddDays(-range).AddDays(SnakeskinGenerator.RandomNumber(0, range));
    }
}