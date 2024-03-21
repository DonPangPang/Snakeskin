using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class IncrementLongIdSnakeskinGenerator : IIncrementLongIdSnakeskinGenerator
{
    private static long _id = 0;

    private static readonly ThreadLocal<long> _threadLocal = new ThreadLocal<long>(() => Interlocked.Increment(ref _id));

    public long Generate()
    {
        return _threadLocal.Value;
    }
}