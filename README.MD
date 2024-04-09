# Snakeskin

简体中文|[English](README_en.MD)

该库的作用是为了在开发过程中，快速生成测试数据。

[![VS Code](https://img.shields.io/badge/VS%20Code-007ACC?style=for-the-badge&logo=visual-studio-code&logoColor=white)](https://code.visualstudio.com/)
[![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)

[![Build and Publish NuGet Packages](https://github.com/wosledon/Snakeskin/actions/workflows/main.yml/badge.svg?branch=master)](https://github.com/wosledon/Snakeskin/actions/workflows/main.yml)
[![ReSharper](https://img.shields.io/badge/ReSharper-Enabled-brightgreen.svg)](https://www.jetbrains.com/resharper/)

| Package | Version | Downloads |
|---------|---------|-----------|
| Snakeskin | [![NuGet version (Snakeskin)](https://img.shields.io/nuget/v/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/) | [![NuGet downloads (Snakeskin)](https://img.shields.io/nuget/dt/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/) |
| Snakeskin.EntityFrameworkCore | [![NuGet version (Snakeskin.EntityFrameworkCore)](https://img.shields.io/nuget/v/Snakeskin.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Snakeskin.EntityFrameworkCore/) | [![NuGet downloads (Snakeskin.EntityFrameworkCore)](https://img.shields.io/nuget/dt/Snakeskin.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Snakeskin.EntityFrameworkCore/) |

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

## Thanks

<a href="https://jb.gg/OpenSourceSupport">
    <img height="80px" src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" alt="JetBrains Logo (Main) logo.">
</a>