using Snakeskin.Core;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class GuidSnakeskinGenerator : IGuidSnakeskinGenerator
{
    public Guid Generate(bool ordered = false)
    {
        return ordered ? GenerateOrdered() : Guid.NewGuid();
    }

    private Guid GenerateOrdered()
    {
        byte[] randomBytes = new byte[10];
        SnakeskinGenerator.RandomBytes(randomBytes);

        long timestamp = DateTime.UtcNow.Ticks / 10000L;
        byte[] timestampBytes = BitConverter.GetBytes(timestamp);

        byte[] guidBytes = new byte[16];
        Buffer.BlockCopy(timestampBytes, 0, guidBytes, 0, 8);
        Buffer.BlockCopy(randomBytes, 0, guidBytes, 8, 8);

        return new Guid(guidBytes);
    }
}