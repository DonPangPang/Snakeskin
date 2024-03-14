using Microsoft.EntityFrameworkCore;
using Snakeskin.EntityFrameworkCore.Core;
using Snakeskin.Enums;
using System.Linq.Expressions;

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

public class SnakeskinFakeBuilder<T>
{
    public SnakeskinFakeBuilder<T> Fake<TProperty>(Expression<Func<T, TProperty>> expression, TProperty value)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeName<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakePhone<TProperty>(Expression<Func<T, TProperty>> expression, CountryCode countryCode = CountryCode.China)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeId<TProperty>(Expression<Func<T, TProperty>> expression, bool ordered = true)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDateTime<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeBoolean<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeInt<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeFloat<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDouble<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDecimal<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeTelephone<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeGuid<TProperty>(Expression<Func<T, TProperty>> expression)
    {
        return this;
    }
}