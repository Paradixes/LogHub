using LogHub.Domain.DomainEvents.Organisation;
using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisation;

public class Organisation : Entity<OrganisationId>
{
    private readonly List<Organisation> _children = new();

    private Organisation() { }

    public UserId CreatorId { get; private set; }

    public string Name { get; private set; }

    public string? Icon { get; private set; }

    public OrganisationId ParentId { get; private set; }

    public IReadOnlyCollection<Organisation> Children => _children;

    public static Organisation Create(string name, string? icon, Organisation parent)
    {
        var organisation = new Organisation
        {
            Id = new OrganisationId(Guid.NewGuid()),
            Name = name,
            Icon = icon,
            ParentId = parent.Id
        };

        parent.AddChild(organisation);

        organisation.Raise(new OrganisationCreatedDomainEvent(
            Guid.NewGuid(),
            organisation.Id,
            organisation.ParentId));

        return organisation;
    }

    private void AddChild(Organisation child)
    {
        _children.Add(child);

        Raise(new OrganisationAddedDomainEvent(
            Guid.NewGuid(),
            Id,
            child.Id));
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
