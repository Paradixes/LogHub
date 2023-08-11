namespace Client.ViewModel;

public record OrganisationModel
{
    public Guid Id { get; set; } = Guid.Empty;

    public Guid OwnerId { get; set; } = Guid.Empty;

    public Guid ParentId { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Logo { get; set; }

    public Uri? LogoUri { get; set; }

    public string InvitationCode { get; set; } = string.Empty;
}
