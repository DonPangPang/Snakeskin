using Snakeskin.EntityFrameworkCore.Extensions;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Snakeskin.EntityFrameworkCore.Core;

public class SnakeskinFakeType
{
    public string Key => _type.Name;
    public string Name => _type.Name;
    public Type ClrType => _type;
    private readonly Type _type;
    private readonly ConcurrentDictionary<string, SnakeskinFakeProperty> _map = new();

    public int Count { get; private set; }

    public void SetCount(int count)
    {
        Count = count;
    }

    public SnakeskinFakeType(Type type)
    {
        _type = type;
        SetTypeMap();
    }

    private void SetTypeMap()
    {
        foreach (var propertyInfo in _type.GetProperties())
        {
            var prop = new SnakeskinFakeProperty(propertyInfo);
            _map[prop.Key] = prop;
        }
    }

    public List<object> ToList(int? count = null)
    {
        var list = new List<object>();
        for (var i = 0; i < (count ?? Count); i++)
        {
            list.Add(FakeOne());
        }

        return list;
    }

    public List<T> ToList<T>(int? count = null) where T : class
    {
        var list = new List<T>();
        for (var i = 0; i < (count ?? Count); i++)
        {
            list.Add(FakeOne<T>());
        }

        return list;
    }

    public object FakeOne()
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

    public T FakeOne<T>() where T : class
    {
        var value = FakeOne();
        Debug.Assert(value != null, nameof(value) + " != null");
        return value.As<T>() ?? throw new NullReferenceException("Generator error");
    }
}