using Domain.Entities.Organisations;

namespace Domain.Exceptions.Organisations;

public class OrganisationNotFoundException : Exception
{
    public OrganisationNotFoundException(OrganisationId id) :
        base($"Organisation with id {id.Value} was not found.") { }

    public OrganisationNotFoundException(string inviteCode) :
        base($"Organisation with invite code {inviteCode} was not found.") { }
}
