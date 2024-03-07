using Snakeskin.Exceptions;

namespace Snakeskin.Core;

internal class SnakeskinGenerator
{
    private static int seed = Environment.TickCount;

    private static readonly ThreadLocal<Random> _threadLocal = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

    public static Random _random { get { return _threadLocal.Value ?? throw new SnakeskinRandomException(); } }

    public static int RandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }

    public static void RandomBytes(byte[] buffer)
    {
        _random.NextBytes(buffer);
    }
}
