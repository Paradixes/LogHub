namespace LogHub.Application.Organisations.AddDepartment;

public record AddDepartmentRequest(
    Guid ManagerId,
    string? Logo,
    string Name,
    string Description);
