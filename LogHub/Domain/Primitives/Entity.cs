namespace LogHub.Domain.Primitives;

public abstract class Entity
{
    private readonly List<DomainEvent> _domainEvents = new();

    public IEnumerable<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
