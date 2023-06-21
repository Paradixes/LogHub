using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResearchHub.Data;

namespace ResearchHub.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ResearchHubContext _db;

        public UsersController(ResearchHubContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return (await _db.Users.ToListAsync()).OrderByDescending(s => s.UserId).ToList();
        }
    }
}
