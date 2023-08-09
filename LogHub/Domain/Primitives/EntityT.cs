namespace Domain.Primitives;

public abstract class Entity<TId> : Entity
    where TId : EntityId
{
    protected Entity()
    {
        Id = (TId)Activator.CreateInstance(typeof(TId), Guid.NewGuid())!;
    }

    public TId Id { get; }
}
