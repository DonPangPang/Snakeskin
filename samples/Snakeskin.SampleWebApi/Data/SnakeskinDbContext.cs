using Microsoft.EntityFrameworkCore;

namespace Snakeskin.SampleWebApi.Data;

public class SnakeskinDbContext(DbContextOptions<SnakeskinDbContext> options) : DbContext(options);