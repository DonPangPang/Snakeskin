using System.Collections.Concurrent;
using Snakeskin.EntityFrameworkCore.Core;

namespace Snakeskin.EntityFrameworkCore;

public class SnakeskinFakeTypeBuilder
{
    private readonly ConcurrentDictionary<string, SnakeskinFakeType> _map = new();

    public SnakeskinFakeType GetFakeType<T>() where T : class
    {
        var key = typeof(T).Name;
        if (_map.TryGetValue(key, out var fakeType))
        {
            return fakeType;
        }

        fakeType = new SnakeskinFakeType(typeof(T));
        _map[key] = fakeType;
        return fakeType;
    }

    public T Fake<T>() where T : class
    {
        return GetFakeType<T>().Fake<T>();
    }
}