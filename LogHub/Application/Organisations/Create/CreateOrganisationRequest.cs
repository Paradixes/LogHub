namespace LogHub.Application.Organisations.Create;

public record CreateOrganisationRequest(
    Guid ManagerId,
    string Name,
    string Description);
