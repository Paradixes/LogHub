using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LogHub.Client.ViewModel;

public class UserViewModel
{
	public Guid Id { get; private set; }

	public string Name { get; private set; }

	public string Email { get; private set; }

	public string Role { get; private set; }

	public static UserViewModel? Create(IEnumerable<Claim> claims)
	{
		var enumerable = claims as Claim[] ?? claims.ToArray();
		var id = Guid.Parse(enumerable.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value ??
							Guid.Empty.ToString());
		var name = enumerable.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value ?? string.Empty;
		var email = enumerable.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value ?? string.Empty;
		var role = enumerable.FirstOrDefault(c => c.Type == "Role")?.Value ?? string.Empty;
		if (id == Guid.Empty
			|| string.IsNullOrWhiteSpace(name)
			|| string.IsNullOrWhiteSpace(email)
			|| string.IsNullOrWhiteSpace(role))
		{
			return null;
		}

		return new UserViewModel
		{
			Id = id,
			Name = name,
			Email = email,
			Role = role
		};
	}
}
