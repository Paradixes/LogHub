namespace Client.ViewModel;

public record OrganisationModel
{
    public Guid OrganisationId { get; set; }

    public Guid ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? Logo { get; set; }
}
