namespace Snakeskin.Exceptions;

internal class SnakeskinRandomException : SnakeskinException
{
    public SnakeskinRandomException(string? message = null, Exception? ex = null) : base(message, ex)
    {
    }
}