using Microsoft.Extensions.DependencyInjection;
using Snakeskin.Generators;
using Snakeskin.IGenerators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakeskin.Core;

internal class SnakeskinBuilder: IDisposable
{
    private static IServiceProvider ServiceProvider = null!;

    public static IServiceCollection Services { get; private set; } = new ServiceCollection();

    public static void Build()
    {
        if (ServiceProvider is not null) return;

        Services.AddSnakeskinPrivate();

        ServiceProvider = Services.BuildServiceProvider();
    }

    public static T GetService<T>() where T: notnull
    {
        Build();

        Debug.Assert(ServiceProvider != null);

        return ServiceProvider.GetRequiredService<T>();
    }


    public void Dispose()
    {
        
    }
}
