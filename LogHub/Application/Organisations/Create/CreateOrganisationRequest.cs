namespace Application.Organisations.Create;

public record CreateOrganisationRequest(
    Guid ManagerId,
    string? Logo,
    string Name,
    string Description,
    Guid ParentId);
