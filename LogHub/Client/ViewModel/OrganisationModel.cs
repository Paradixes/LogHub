namespace Client.ViewModel;

public class OrganisationModel
{
    public Guid ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Logo { get; set; }
}