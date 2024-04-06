using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakeskin.SampleWebApi.Data;

namespace Snakeskin.SampleWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly SnakeskinDbContext _dbContext;

    public UserController(SnakeskinDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _dbContext.Users.ToListAsync();

        return Ok(users);
    }

    [HttpGet]
    public async Task<IActionResult> Count()
    {
        var count = await _dbContext.Users.CountAsync();

        return Ok(count);
    }
}