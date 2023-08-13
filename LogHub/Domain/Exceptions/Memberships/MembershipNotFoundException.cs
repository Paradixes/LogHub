﻿using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Exceptions.Memberships;

public class MembershipNotFoundException : Exception
{
    public MembershipNotFoundException(UserId userId, OrganisationId organisationId)
        : base($"Membership for user {userId} in organisation {organisationId} was not found.") { }
}
