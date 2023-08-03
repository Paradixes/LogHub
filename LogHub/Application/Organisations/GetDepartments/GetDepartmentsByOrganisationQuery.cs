using Application.Abstracts.Messaging;
using Application.Departments.GetById;

namespace Application.Organisations.GetDepartments;

public record GetDepartmentsByOrganisationQuery(Guid OrganisationId) : IQuery<List<DepartmentResponse>>;
