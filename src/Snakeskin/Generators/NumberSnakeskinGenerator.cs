using Snakeskin.Core;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class NumberSnakeskinGenerator : INumberSnakeskinGenerator
{
    public int GenerateInt(int min = 0, int max = 100)
    {
        return SnakeskinGenerator.RandomNumber(min, max);
    }

    public float GenerateFloat(float min = 0, float max = 100)
    {
        return (float)(SnakeskinGenerator.RandomNumber((int)(min * 100), (int)(max * 100)) / 100.0);
    }

    public double GenerateDouble(double min = 0, double max = 100)
    {
        return SnakeskinGenerator.RandomNumber((int)(min * 100), (int)(max * 100)) / 100.0;
    }

    public decimal GenerateDecimal(decimal min = 0, decimal max = 100)
    {
        return SnakeskinGenerator.RandomNumber((int)(min * 100), (int)(max * 100)) / 100.0m;
    }
}