using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snakeskin.EntityFrameworkCore.Core;

namespace Snakeskin.EntityFrameworkCore;

public static class SnakeskinEntityFrameworkCoreExtensions
{
    public static IServiceCollection Fake<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext,new()
    {

        var dbcontext = new TDbContext();

        var types = dbcontext.Model.GetEntityTypes();
        foreach (var entityType in types)
        {
            
        }

        return services;
    }

    private static void AddFakeData(Type entityType)
    {
        var props = entityType.GetProperties().Where(x => x is { CanRead: true, CanWrite: true });
        foreach (var prop in props)
        {
            if (prop.PropertyType == typeof(string))
            {
                
            }
        }
    }
}
