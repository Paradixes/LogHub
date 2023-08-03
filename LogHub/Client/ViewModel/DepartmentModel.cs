namespace Client.ViewModel;

public record DepartmentModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Uri? Logo { get; set; }
    public Guid ManagerId { get; set; }
    public Guid OrganisationId { get; set; }
}
