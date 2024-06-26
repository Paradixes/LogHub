﻿using Application.Organisations.GetById;
using MediatR;

namespace Application.Users.Users.GetRootOrganisations;

public record GetRootOrganisationsByIdQuery(Guid UserId) : IRequest<List<OrganisationResponse>>;