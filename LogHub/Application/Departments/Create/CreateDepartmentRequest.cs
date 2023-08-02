namespace Application.Departments.Create;

public record CreateDepartmentRequest(
    Guid ManagerId,
    string? Logo,
    string Name,
    string Description);
