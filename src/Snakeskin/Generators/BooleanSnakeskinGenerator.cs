using Snakeskin.Core;
using Snakeskin.IGenerators;

namespace Snakeskin.Generators;

public class BooleanSnakeskinGenerator : IBooleanSnakeskinGenerator
{
    public bool Generate()
    {
        return SnakeskinGenerator.RandomNumber(0, 2) == 1;
    }

    public bool Generate(bool value)
    {
        return value;
    }

    /// <summary>
    /// �ٷֱ�����
    /// </summary>
    /// <param name="probability"> ���ܵ�ռ��, ����0~1 </param>
    /// <returns> </returns>
    /// <exception cref="ArgumentOutOfRangeException"> </exception>
    public bool Generate(float probability)
    {
        if (probability < 0 || probability > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0 and 1.");
        }

        return SnakeskinGenerator.RandomNumber(0, 100) < probability * 100;
    }
}