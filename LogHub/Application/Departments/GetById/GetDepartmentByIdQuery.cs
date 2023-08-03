using Application.Abstracts.Messaging;

namespace Application.Departments.GetById;

public sealed record GetDepartmentByIdQuery(Guid DepartmentId) : IQuery<DepartmentResponse>;
