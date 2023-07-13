namespace LogHub.Domain.Primitives;

public abstract class Entity<TId>
    where TId : EntityId
{
    private readonly List<DomainEvent> _domainEvents = new();

    protected Entity(TId? id = null)
    {
        Id = id ?? Activator.CreateInstance<TId>();
    }

    public TId Id { get; protected init; }

    public IReadOnlyCollection<DomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
