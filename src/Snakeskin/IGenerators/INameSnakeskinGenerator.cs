namespace Snakeskin.IGenerators;

public interface INameSnakeskinGenerator : ISnakeskinGenerator
{
    string Generate(int digit = 2);

    string Generator(int length, string? chars = null, bool lowerCase = false);

    string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false);
}