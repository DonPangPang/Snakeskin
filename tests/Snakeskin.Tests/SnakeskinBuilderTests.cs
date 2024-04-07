using Microsoft.Extensions.DependencyInjection;
using Snakeskin.Generators;
using Snakeskin.IGenerators;

namespace Snakeskin.Tests;

public class SnakeskinBuilderTests
{
    [Fact]
    public void BuildTest()
    {
        var services = new ServiceCollection();

        services.AddSnakeskin();

        var builder = services.BuildServiceProvider();

        var generator = builder.GetService<INumberSnakeskinGenerator>();

        Assert.NotNull(generator);

        Assert.IsType<NumberSnakeskinGenerator>(generator);

        var value = generator.GenerateInt();
        var value1 = generator.GenerateInt();
        var value2 = generator.GenerateInt();
        var value3 = generator.GenerateInt();
        var value4 = generator.GenerateInt();
        var value5 = generator.GenerateInt();
        Assert.True(value >= 0);
    }

    [Fact]
    public void ConfigurationTest()
    {
        var seeds = SnakeskinConfiguration.GetSeeds();
    }
}