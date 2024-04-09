# Snakeskin

¼òÌåÖÐÎÄ|[English](README_en.md)

[![Build Status](https://dev.azure.com/zhongdi/Snakeskin/_apis/build/status/Snakeskin-CI?branchName=master)](https://dev.azure.com/zhongdi/Snakeskin/_build/latest?definitionId=1&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/)
[![ReSharper](https://img.shields.io/badge/ReSharper-Enabled-brightgreen.svg)](https://www.jetbrains.com/resharper/)

The purpose of this library is to quickly generate test data during the development process.

## Usage

```csharp
public class SnakeskinDbContext(DbContextOptions<SnakeskinDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Fake<User>()
            .WithCount(10_000);

        modelBuilder.CommitFake();

        base.OnModelCreating(modelBuilder);
    }
}
```