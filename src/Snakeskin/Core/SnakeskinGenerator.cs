using Snakeskin.Exceptions;

namespace Snakeskin.Core;

public class SnakeskinGenerator
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

    public static long ExtractRandom(int extract = 2)
    {
        if (extract >= sizeof(long) * 2)
            throw new ArgumentOutOfRangeException(nameof(extract));

        long mask = (1L << (extract * 4) + 1) - 1;
        return DateTime.UtcNow.Ticks & mask;
    }

    private const long _quickRandomMask = 1L << 32 - 1;

    private static QuickRandom _quick = new QuickRandom((ulong)seed);
    public static int QuickRandomNumber(int length)
    {
        return (int)_quick.Next(0, 100);
    }

    public static int QuickRandomNumber(int min, int max)
    {
        return (int)_quick.Next((ulong)min, (ulong)max);
    }

    //XorShift
    private class QuickRandom
    {
        private ulong _state;

        public QuickRandom(ulong seed)
        {
            _state = seed;
        }

        public ulong Next()
        {
            var x = _state;
            x ^= x << 13;
            x ^= x >> 7;
            x ^= x << 17;
            return _state = x;
        }

        public ulong Next(ulong minValue, ulong maxValue)
        {
            return (Next() - minValue) % (maxValue - minValue) + minValue;
        }
    }
}

