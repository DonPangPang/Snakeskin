namespace Snakeskin.IGenerators;

public interface IStringSnakeskinGenerator : ISnakeskinGenerator
{
    string Generate();

    string Generator(int length, string? chars = null, bool lowerCase = false);

    string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false);
}