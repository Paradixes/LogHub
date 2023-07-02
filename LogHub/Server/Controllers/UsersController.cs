using LogHub.Server.Data;
using LogHub.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Server.Controllers;

[ApiController]
[Route("user")]
public class UsersController : ControllerBase
{
    private readonly LogHubContext _db;

    public UsersController(LogHubContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return (await _db.Users.ToListAsync()).OrderByDescending(s => s.UserId).ToList();
    }
}
