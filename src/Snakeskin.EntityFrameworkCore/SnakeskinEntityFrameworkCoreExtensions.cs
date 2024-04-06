using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Snakeskin.EntityFrameworkCore;

public static class SnakeskinEntityFrameworkCoreExtensions
{
    private static readonly SnakeskinEntityFrameworkCoreBuilder Builder = new();

    public static SnakeskinFakeTypeBuilder<T> Fake<T>(this ModelBuilder modelBuilder) where T : class
    {
        var builder = Builder.FakeTypeCollection.GetFakeTypeBuilder<T>();

        return builder;
    }

    public static T FakeOne<T>(this DbContext context) where T : class
    {
        var builder = Builder.FakeTypeCollection.GetFakeTypeBuilder<T>();

        return builder.Fake().Build().FakeOne<T>();
    }

    public static async Task CommitFakeAsync<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
    {
        using var scoped = app.ApplicationServices.CreateScope();
        var context = scoped.ServiceProvider.GetRequiredService<TDbContext>();

        foreach (var fakeTypeBuilder in Builder.FakeTypeCollection.Values)
        {
            var fakeType = fakeTypeBuilder.Build();

            var batchSize = 1000;
            for (var i = 0; i < fakeType.Count; i += batchSize)
            {
                var count = Math.Min(batchSize, fakeType.Count - i);
                var batch = fakeType.ToList(count);
                context.ChangeTracker.AutoDetectChangesEnabled = false; // Disable change tracking
                context.AddRange(batch);
                await context.SaveChangesAsync();
                context.ChangeTracker.AutoDetectChangesEnabled = true; // Enable change tracking
                context.ChangeTracker.AcceptAllChanges(); // Confirm changes
            }
        }
    }
}