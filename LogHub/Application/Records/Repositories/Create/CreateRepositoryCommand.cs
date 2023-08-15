using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Records.Repositories.Create;

public record CreateRepositoryCommand(
    UserId CreatorId,
    OrganisationId OrganisationId,
    string Title,
    string? Description,
    string? Icon,
    DataManagementPlanResponse DataManagementPlan) : IRequest<Guid>;
