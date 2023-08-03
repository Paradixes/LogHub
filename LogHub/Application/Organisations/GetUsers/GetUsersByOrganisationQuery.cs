using Application.Abstracts.Messaging;
using Application.Users.GetById;
using Domain.Entities.Organisations;

namespace Application.Organisations.GetUsers;

public record GetUsersByOrganisationQuery(OrganisationId OrganisationId) : IQuery<List<UserResponse>>;
