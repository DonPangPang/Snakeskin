namespace Snakeskin.Exceptions;

internal class SnakeskinGeneratorNotImplementedException : SnakeskinGeneratorException
{
    public SnakeskinGeneratorNotImplementedException(string? message = null, Exception? ex = null) : base(message, ex)
    {
    }
}