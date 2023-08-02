namespace Application.Organisations.GetById;

public sealed record OrganisationResponse(
    Guid Id,
    string Name,
    Uri? LogoUri,
    string? Description);