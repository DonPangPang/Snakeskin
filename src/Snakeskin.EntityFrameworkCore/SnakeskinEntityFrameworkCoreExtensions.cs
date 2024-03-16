using Microsoft.EntityFrameworkCore;
using Snakeskin.EntityFrameworkCore.Core;

namespace Snakeskin.EntityFrameworkCore;

public static class SnakeskinEntityFrameworkCoreExtensions
{
    private static readonly SnakeskinEntityFrameworkCoreBuilder _builder = new();

    public static ModelBuilder FakeAll(this ModelBuilder modelBuilder)
    {
        return modelBuilder;
    }

    public static SnakeskinEntityFrameworkCoreBuilder Fake<T>(this ModelBuilder modelBuilder, Action<SnakeskinFakeBuilder<T>> exp)
    {
        return _builder;
    }
}
