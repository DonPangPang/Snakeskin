# Snakeskin

简体中文 | [English](README_en.MD)

The purpose of this library is to quickly generate test data during the development process.

[![Build and Publish NuGet Packages](https://github.com/wosledon/Snakeskin/actions/workflows/main.yml/badge.svg)](https://github.com/wosledon/Snakeskin/actions/workflows/main.yml)
[![ReSharper](https://img.shields.io/badge/ReSharper-Enabled-brightgreen.svg)](https://www.jetbrains.com/resharper/)

| Package | Version | Downloads |
|---------|---------|-----------|
| Snakeskin | [![NuGet version (Snakeskin)](https://img.shields.io/nuget/v/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/) | [![NuGet downloads (Snakeskin)](https://img.shields.io/nuget/dt/Snakeskin.svg)](https://www.nuget.org/packages/Snakeskin/) |
| Snakeskin.EntityFrameworkCore | [![NuGet version (Snakeskin.EntityFrameworkCore)](https://img.shields.io/nuget/v/Snakeskin.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Snakeskin.EntityFrameworkCore/) | [![NuGet downloads (Snakeskin.EntityFrameworkCore)](https://img.shields.io/nuget/dt/Snakeskin.EntityFrameworkCoresvg)](https://www.nuget.org/packages/Snakeskin.EntityFrameworkCore/) |

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

## Thanks

<a href="https://jb.gg/OpenSourceSupport">
    <img height="80px" src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" alt="JetBrains Logo (Main) logo.">
</a>
<a href="https://code.visualstudio.com/">
    <img height="70px" src="https://upload.wikimedia.org/wikipedia/commons/9/9a/Visual_Studio_Code_1.35_icon.svg" alt="Visual Studio Code logo.">
</a>
