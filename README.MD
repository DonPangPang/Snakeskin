# Snakeskin

简体中文|[English](README_en.MD)

[![Build Status](https://dev.azure.com/zhongdi/Snakeskin/_apis/build/status/Snakeskin-CI?branchName=master)](https://dev.azure.com/zhongdi/Snakeskin/_build/latest?definitionId=1&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/)
[![ReSharper](https://img.shields.io/badge/ReSharper-Enabled-brightgreen.svg)](https://www.jetbrains.com/resharper/)

该库的作用是为了在开发过程中，快速生成测试数据。

## 使用方法

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