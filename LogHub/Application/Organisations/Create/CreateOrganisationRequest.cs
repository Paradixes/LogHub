namespace Application.Organisations.Create;

public record CreateOrganisationRequest(
    Guid OwnerId,
    string? Logo,
    string Name,
    string Description,
    Guid? ParentId);