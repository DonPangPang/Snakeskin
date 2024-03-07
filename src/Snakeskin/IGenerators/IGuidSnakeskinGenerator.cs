
namespace Snakeskin.IGenerators;

public interface IGuidSnakeskinGenerator : ISnakeskinGenerator
{
    Guid Generate(bool ordered = false);
}
