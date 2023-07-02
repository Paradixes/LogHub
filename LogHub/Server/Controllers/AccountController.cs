using LogHub.Shared.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogHub.Server.Controllers;

[ApiController]
[Route("API/[controller]")]
public class AccountController : ControllerBase
{
    public AccountController() { }

    [HttpPost]
    public IActionResult GenerateTokenAsync(LoginViewModel model)
    {
        // TODO: Database IO
        // TODO: Password Cryptor
        UserInfo user = new()
        {
            Email = "admin@admin.com",
            Role = "Administrator",
            Password = "12345",
        };

        // Generate JWT Token
        var key = "QOEIFJOWIH329834ROWKJENFADWEQWEQDSQWDQWE";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var header = new JwtHeader(new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

        var userClaim = new List<Claim>();
        userClaim.Add(new(ClaimTypes.Email, user.Email));
        userClaim.Add(new(ClaimTypes.Role, user.Role));

        var payload = new JwtPayload(userClaim);

        var token = new JwtSecurityToken(header, payload);

        var handler = new JwtSecurityTokenHandler();
        string jwtToken = handler.WriteToken(token);

        return Ok(jwtToken);
    }
}

class UserInfo
{
    public string Email { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
}
