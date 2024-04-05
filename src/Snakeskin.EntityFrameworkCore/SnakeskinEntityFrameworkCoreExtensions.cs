using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Snakeskin.EntityFrameworkCore;

public static class SnakeskinEntityFrameworkCoreExtensions
{
    private static readonly SnakeskinEntityFrameworkCoreBuilder Builder = new();

    public static SnakeskinEntityFrameworkCoreBuilder Fake<T>(this ModelBuilder modelBuilder) where T : class
    {
        modelBuilder.Entity<T>().HasData(Builder.FakeTypeBuilder.Fake<T>());

        return Builder;
    }


    public static T FakeOne<T>(this DbContext context) where T : class
    {
        return Builder.FakeTypeBuilder.Fake<T>();
    }
}