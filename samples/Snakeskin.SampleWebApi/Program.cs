using Microsoft.EntityFrameworkCore;
using Snakeskin.EntityFrameworkCore;
using Snakeskin.SampleWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SnakeskinDbContext>(opts =>
{
    opts.UseSqlite("Data Source=samples.db", t => t.MaxBatchSize(5000));
    opts.LogTo(Console.WriteLine);
});

var app = builder.Build();

var scope = app.Services.CreateScope();
try
{
    var dbContext = scope.ServiceProvider.GetService<SnakeskinDbContext>();

    dbContext?.Database.EnsureDeleted();
    dbContext?.Database.EnsureCreated();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//await app.CommitFakeAsync<SnakeskinDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();