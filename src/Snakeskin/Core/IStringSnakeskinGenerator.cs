namespace Snakeskin.Core;

public interface IStringSnakeskinGenerator : ISnakeskinGenerator<string>
{
    string Generator(int length, string? chars = null, bool lowerCase = false);
    string Generator(int minLength, int maxLength, string? chars = null, bool lowerCase = false);
}
