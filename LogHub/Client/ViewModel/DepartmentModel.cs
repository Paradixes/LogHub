namespace Client.ViewModel;

public record DepartmentModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Uri? Logo { get; set; }
    public Guid ManagerId { get; set; } = Guid.Empty;
    public Guid OrganisationId { get; set; }
}
