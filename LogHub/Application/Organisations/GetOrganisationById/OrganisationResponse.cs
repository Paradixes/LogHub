namespace LogHub.Application.Organisations.GetOrganisationById;

public sealed record OrganisationResponse(
    Guid Id,
    string Name,
    Uri? LogoUri,
    string? Description);