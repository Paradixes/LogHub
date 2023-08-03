namespace Application.Departments.GetById;

public sealed record DepartmentResponse(
    Guid Id,
    string Name,
    string? Description,
    Uri? Logo,
    Guid ManagerId,
    Guid OrganisationId);