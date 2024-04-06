using System.Collections.Concurrent;
using System.Diagnostics;
using Snakeskin.EntityFrameworkCore.Core;

namespace Snakeskin.EntityFrameworkCore;

public interface ISnakeskinFakeTypeBuilder
{
    SnakeskinFakeType Build();
}

public class SnakeskinFakeTypeBuilder<T> : ISnakeskinFakeTypeBuilder
    where T : class
{
    private readonly SnakeskinFakeType _fakeType = new(typeof(T));

    public SnakeskinFakeTypeBuilder<T> Fake()
    {
        _fakeType.FakeOne<T>();

        return this;
    }

    public SnakeskinFakeTypeBuilder<T> WithCount(int count)
    {
        _fakeType.SetCount(count);
        return this;
    }

    public SnakeskinFakeType Build()
    {
        Debug.Assert(_fakeType != null, nameof(_fakeType) + " != null");

        return _fakeType;
    }
}

public class SnakeskinFakeTypeCollection : ConcurrentDictionary<string, ISnakeskinFakeTypeBuilder>
{
    public SnakeskinFakeTypeBuilder<T> GetFakeTypeBuilder<T>() where T : class
    {
        var key = typeof(T).Name;
        if (TryGetValue(key, out var fakeTypeBuilder))
        {
            return (SnakeskinFakeTypeBuilder<T>)fakeTypeBuilder;
        }

        fakeTypeBuilder = new SnakeskinFakeTypeBuilder<T>();
        this[key] = fakeTypeBuilder;
        return (SnakeskinFakeTypeBuilder<T>)fakeTypeBuilder;
    }
}