namespace Snakeskin.Exceptions;

internal class SnakeskinGeneratorValidationException : SnakeskinGeneratorException
{
    public SnakeskinGeneratorValidationException(string? message = null, Exception? ex = null) : base(message, ex)
    {
    }
}
