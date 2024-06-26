﻿using Application.Records.DataManagementPlanTemplates.GetById;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Records.DataManagementPlanTemplates.Create;

public record CreateDataManagementPlanTemplateCommand(
    OrganisationId OrganisationId,
    UserId CreatorId,
    string Title,
    string? Icon,
    string? Description,
    IEnumerable<QuestionResponse> Questions) : IRequest<Guid>;