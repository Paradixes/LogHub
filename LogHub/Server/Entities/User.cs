using System.ComponentModel.DataAnnotations;

namespace LogHub.Server.Entities;

public class User
{
	[Key]
	public long UserId { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Role { get; set; } = string.Empty;
	public string Organization { get; set; } = string.Empty;
	public string PersonalOrcid { get; set; } = string.Empty;
}
