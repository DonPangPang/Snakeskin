namespace Snakeskin.IGenerators;

public interface INumberSnakeskinGenerator : ISnakeskinGenerator
{
    decimal GenerateDecimal(decimal min = 0, decimal max = 100);

    double GenerateDouble(double min = 0, double max = 100);

    float GenerateFloat(float min = 0, float max = 100);

    int GenerateInt(int min = 0, int max = 100);
}