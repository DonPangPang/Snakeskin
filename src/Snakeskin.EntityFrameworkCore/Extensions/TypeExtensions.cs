namespace Snakeskin.EntityFrameworkCore.Extensions;

public static class TypeExtensions
{
    public static T? As<T>(this object arg)
    {
        try
        {
            if (arg is null) return default;

            return (T)arg;
        }
        catch
        {
            return default;
        }
    }
}