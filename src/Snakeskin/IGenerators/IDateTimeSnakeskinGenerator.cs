
namespace Snakeskin.IGenerators;

public interface IDateTimeSnakeskinGenerator : ISnakeskinGenerator
{
    DateTime Generate(DateTime min, DateTime max);
    DateTime Generate();
}
