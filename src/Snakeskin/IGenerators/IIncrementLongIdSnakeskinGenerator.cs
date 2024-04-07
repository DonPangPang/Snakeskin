namespace Snakeskin.IGenerators;

public interface IIncrementLongIdSnakeskinGenerator : ISnakeskinGenerator
{
    long Generate();
}