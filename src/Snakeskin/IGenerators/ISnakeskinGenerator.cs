namespace Snakeskin.IGenerators;

public interface ISnakeskinGenerator
{
}

[Obsolete("弃用的设计")]
public interface ISnakeskinGenerator<T> : ISnakeskinGenerator
{
}