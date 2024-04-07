using Microsoft.EntityFrameworkCore;
using Snakeskin.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Snakeskin.SampleWebApi.Data;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}

public class SnakeskinDbContext(DbContextOptions<SnakeskinDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Fake<User>()
            .WithCount(10_000);

        base.OnModelCreating(modelBuilder);
    }
}