namespace Application.Organisations.Update;

public record UpdateOrganisationRequest(
    string Name,
    string? Logo,
    string? Description,
    Guid? OwnerId);
