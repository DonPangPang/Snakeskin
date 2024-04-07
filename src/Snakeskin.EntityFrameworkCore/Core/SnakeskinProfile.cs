namespace Snakeskin.EntityFrameworkCore.Core;

public class SnakeskinProfile
{
    public SnakeskinProfile()
    {
        CreateFake<User>(x =>
        {
            x.Id = Snakeskin.Int();
            x.Name = Snakeskin.Name();
        });
    }

    public SnakeskinFakeBuilder<T> CreateFake<T>(Action<T> action)
    {
        return new SnakeskinFakeBuilder<T>();
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Role
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string Name { get; set; }
}