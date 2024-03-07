namespace Snakeskin.Exceptions;

internal class SnakeskinGeneratorException : SnakeskinException
{
    public SnakeskinGeneratorException(string? message = null, Exception? ex = null) : base(message, ex)
    {
    }
}
