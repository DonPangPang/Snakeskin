using Microsoft.EntityFrameworkCore;
using Snakeskin.EntityFrameworkCore.Core;
using System.Linq.Expressions;

namespace Snakeskin.EntityFrameworkCore;

public static class SnakeskinEntityFrameworkCoreExtensions
{
    private static readonly SnakeskinEntityFrameworkCoreBuilder _builder = new();

    public static ModelBuilder FakeAll(this ModelBuilder modelBuilder)
    {
        modelBuilder.Fake<User>(x =>
        {
            x.FakeId(x => x.Id, true);
            x.FakeName(x => x.Name);
            x.FakePhone(x => x.Phone);
        }).WithCount(100);

        return modelBuilder;
    }

    public static SnakeskinEntityFrameworkCoreBuilder Fake<T>(this ModelBuilder modelBuilder, Action<SnakeskinFakeBuilder<T>> exp)
    {
        return _builder;
    }

    public static SnakeskinEntityFrameworkCoreBuilder WithCount(this SnakeskinEntityFrameworkCoreBuilder builder, int count)
    {
        return builder;
    }
}

public class SnakeskinFakeBuilder<T>
{
    public SnakeskinFakeBuilder<T> Fake<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeName<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakePhone<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeValue<TProperty>(Expression<Func<T, TProperty>> expression, TProperty value)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeId<TProperty>(Expression<Func<T, TProperty>> expression, bool ordered = true)
    {
        return this;
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}