using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class IncrementIntIdSnakeskinGenerator : IIncrementIntIdSnakeskinGenerator
{
    private static int _id = 0;

    private static readonly ThreadLocal<int> _threadLocal = new ThreadLocal<int>(() => Interlocked.Increment(ref _id));

    public int Generate()
    {
        return _threadLocal.Value;
    }
}