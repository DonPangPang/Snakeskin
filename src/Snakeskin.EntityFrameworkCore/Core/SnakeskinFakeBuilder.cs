using Snakeskin.Enums;
using System.Linq.Expressions;

namespace Snakeskin.EntityFrameworkCore.Core;

public class SnakeskinFakeBuilder<T>
{
    public SnakeskinFakeBuilder<T> Fake<TProperty>(Expression<Func<T, TProperty>> expression, TProperty value)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeName(Expression<Func<T, string>> expression)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakePhone(Expression<Func<T, string>> expression, CountryCode countryCode = CountryCode.China)
    {
        return this;
    }
    public SnakeskinFakeBuilder<T> FakeId(Expression<Func<T, int>> expression, bool ordered = true)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDateTime(Expression<Func<T, DateTime>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeBoolean(Expression<Func<T, bool>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeInt(Expression<Func<T, int>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeFloat(Expression<Func<T, float>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDouble(Expression<Func<T, double>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeDecimal(Expression<Func<T, decimal>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeTelephone(Expression<Func<T, string>> expression)
    {
        return this;
    }

    public SnakeskinFakeBuilder<T> FakeGuid(Expression<Func<T, Guid>> expression)
    {
        return this;
    }
}