namespace Domain.Primitives;

public static class GuidExtensions
{
    public static TId? Create<TId>(this Guid id)
        where TId : EntityId
    {
        return (TId?)(Activator.CreateInstance(typeof(TId), id) ?? null);
    }
}