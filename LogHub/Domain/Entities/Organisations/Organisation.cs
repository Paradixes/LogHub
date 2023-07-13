using LogHub.Domain.DomainEvents.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public class Organisation : Entity<OrganisationId>
{
    private Organisation() { }

    public UserId CreatorId { get; private set; }

    public string Name { get; private set; }

    public string? Icon { get; private set; }

    public OrganisationId ParentId { get; private set; }

    public static Organisation Create(string name, string? icon, UserId creatorId, Organisation parent)
    {
        var organisation = new Organisation
        {
            Id = new OrganisationId(Guid.NewGuid()),
            CreatorId = creatorId,
            Name = name,
            Icon = icon,
            ParentId = parent.Id
        };

        organisation.Raise(new OrganisationCreatedDomainEvent(
            Guid.NewGuid(),
            organisation.Id,
            organisation.ParentId));

        parent.Raise(new OrganisationAddedDomainEvent(
            Guid.NewGuid(),
            parent.Id,
            organisation.Id));

        return organisation;
    }

    public void Update(string name, string? icon)
    {
        if (Name != name || Icon != icon)
        {
            Raise(new OrganisationUpdatedDomainEvent(
                Guid.NewGuid(),
                Id,
                ParentId));
        }

        Name = name;
        Icon = icon;
    }

    public void TransferOwnership(UserId newOwnerId)
    {
        if (CreatorId != newOwnerId)
        {
            Raise(new OrganisationOwnershipTransferredDomainEvent(
                Guid.NewGuid(),
                Id,
                CreatorId,
                newOwnerId));
        }

        CreatorId = newOwnerId;
    }
}