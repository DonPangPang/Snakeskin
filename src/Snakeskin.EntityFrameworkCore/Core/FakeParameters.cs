using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Snakeskin.EntityFrameworkCore.Extensions;

namespace Snakeskin.EntityFrameworkCore.Core;

public class FakeParameters(PropertyInfo propertyInfo)
{
    private int? _minValue = null;

    public int MinValue
    {
        get
        {
            if (_minValue is not null) return _minValue ?? 0;

            var attr = propertyInfo.GetCustomAttribute<RangeAttribute>();
            if (attr is not null)
                _minValue = attr.Minimum.As<int>();

            return _minValue ?? 0;
        }
    }

    private int? _maxValue = null;

    public int MaxValue
    {
        get
        {
            if (_maxValue is not null) return _maxValue ?? 100;
            var attr = propertyInfo.GetCustomAttribute<RangeAttribute>();
            if (attr is not null)
                _maxValue = attr.Maximum.As<int>();

            return _maxValue ?? 100;
        }
    }

    private int? _minLength = null;

    public int MinLength
    {
        get
        {
            if (_minLength is not null) return _minLength ?? 1;
            var attr = propertyInfo.GetCustomAttribute<MinLengthAttribute>();
            if (attr is not null)
                _minLength = attr.Length;
            return _minLength ?? 1;
        }
    }

    private int? _maxLength = null;

    public int MaxLength
    {
        get
        {
            if (_maxLength is not null) return _maxLength ?? 100;
            var attr = propertyInfo.GetCustomAttribute<MaxLengthAttribute>();
            if (attr is not null)
                _maxLength = attr.Length;
            return _maxLength ?? 100;
        }
    }
}