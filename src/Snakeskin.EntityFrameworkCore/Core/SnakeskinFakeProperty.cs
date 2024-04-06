using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace Snakeskin.EntityFrameworkCore.Core;

public class SnakeskinFakeProperty
{
    public string Key => PropertyName;
    public string PropertyName => _propertyInfo.Name;
    public Func<FakeParameters, object> ValueGenerator { get; set; } = null!;
    public FakeParameters FakeParameters { get; set; }

    private readonly PropertyInfo _propertyInfo;

    private readonly ConcurrentDictionary<(Type, Func<string, bool>), Func<FakeParameters, object>> _map = new()
    {
        [(typeof(int), _ => true)] = args => Snakeskin.Int(args.MinValue, args.MaxValue),
        [(typeof(string), name => name.Contains("name", StringComparison.OrdinalIgnoreCase))] = args => Snakeskin.Name(),
        //[(typeof(string), name => name.EndsWith("address", StringComparison.OrdinalIgnoreCase))] = args => Snakeskin.String(args.MinValue, args.MaxValue),
        [(typeof(DateTime), _ => true)] = args => Snakeskin.DateTime(),
        [(typeof(bool), _ => true)] = args => Snakeskin.Boolean(),
        [(typeof(Guid), _ => true)] = args => Snakeskin.Guid(),
        [(typeof(decimal), _ => true)] = args => Snakeskin.Decimal(args.MinValue, args.MaxValue),
        [(typeof(double), _ => true)] = args => Snakeskin.Double(args.MinValue, args.MaxValue),
        [(typeof(float), _ => true)] = args => Snakeskin.Float(args.MinValue, args.MaxValue),
        [(typeof(Guid), _ => true)] = args => Snakeskin.Guid(),
        [(typeof(decimal), _ => true)] = args => Snakeskin.Decimal(args.MinValue, args.MaxValue),
        [(typeof(double), _ => true)] = args => Snakeskin.Double(args.MinValue, args.MaxValue),
        [(typeof(float), _ => true)] = args => Snakeskin.Float(args.MinValue, args.MaxValue),
        // 其他类型...
    };

    public SnakeskinFakeProperty(PropertyInfo propertyInfo)
    {
        _propertyInfo = propertyInfo;
        FakeParameters = new FakeParameters(propertyInfo);
        SetPropertyMap();
    }

    private void SetPropertyMap()
    {
        var key = _map.Keys.FirstOrDefault(k => k.Item1 == _propertyInfo.PropertyType && k.Item2(PropertyName));

        if (key != default && _map.TryGetValue(key, out var generator))
        {
            ValueGenerator = generator;
        }
        else
        {
            // 如果没有找到匹配的生成器，可以抛出一个异常，或者设置一个默认的生成器
            throw new ArgumentException($"Unknown property type or name: {PropertyName}");
        }
    }

    public object Fake()
    {
        Debug.Assert(ValueGenerator is not null);

        return ValueGenerator(FakeParameters);
    }
}