namespace Snakeskin.IGenerators;

public interface IBooleanSnakeskinGenerator : ISnakeskinGenerator
{
    bool Generate();

    bool Generate(float probability);
}