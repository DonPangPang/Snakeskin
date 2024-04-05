using System.Collections.Concurrent;
using System.Diagnostics;
using Snakeskin.EntityFrameworkCore.Extensions;

namespace Snakeskin.EntityFrameworkCore.Core;

public class SnakeskinFakeType
{
    public string Key => _type.Name;
    private readonly Type _type;
    private readonly ConcurrentDictionary<string, SnakeskinFakeProperty> _map = new();

    public int Count { get; private set; }

    public SnakeskinFakeType(Type type, int count = 100)
    {
        _type = type;
        SetTypeMap();
        Count = count;
    }

    private void SetTypeMap()
    {
        foreach (var propertyInfo in _type.GetProperties())
        {
            var prop = new SnakeskinFakeProperty(propertyInfo);
            _map[prop.Key] = prop;
        }
    }

    public object Fake()
    {
        var instance = Activator.CreateInstance(_type);
        foreach (var prop in _map.Values)
        {
            var value = prop.Fake();
            _type.GetProperty(prop.PropertyName)?.SetValue(instance, value);
        }

        Debug.Assert(instance != null, nameof(instance) + " != null");
        return instance;
    }

    public T Fake<T>() where T : class
    {
        var value = Fake();
        Debug.Assert(value != null, nameof(value) + " != null");
        return value.As<T>() ?? throw new NullReferenceException("Generator error");
    }
}