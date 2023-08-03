using Shared.Enums;

namespace Client.ViewModel;

public class UserAccountModel
{
    public Guid Id { get; set; }
    public Uri? AvatarUri { get; set; }
    public string? Avatar { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Profession { get; set; }
    public Guid? OrganisationId { get; set; }
    public string? OrganisationName { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public string? Orcid { get; set; }
    public UserRole Role { get; set; }
}
