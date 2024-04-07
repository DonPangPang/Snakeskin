namespace Snakeskin.Exceptions;

internal class SnakeskinGeneratorNotSupportedException : SnakeskinGeneratorException
{
    public SnakeskinGeneratorNotSupportedException(string? message = null, Exception? ex = null) : base(message, ex)
    {
    }
}