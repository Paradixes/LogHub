﻿using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Shared.Enums;

namespace Domain.Entities.Middlewares;

public class OrganisationMembership
{
    private OrganisationMembership() { }

    internal OrganisationMembership(OrganisationId organisationId, UserId userId, OrganisationRole role)
    {
        OrganisationId = organisationId;
        UserId = userId;
        Role = role;
    }

    public OrganisationId OrganisationId { get; private init; } = null!;

    public UserId UserId { get; private init; } = null!;

    public OrganisationRole Role { get; private set; } = OrganisationRole.Member;

    public void UpdateRole(OrganisationRole role)
    {
        Role = role;
    }
}