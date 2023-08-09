namespace Domain.Primitives;

public static class GuidExtensions
{
    public static TId? Create<TId>(this Guid id)
        where TId : EntityId
    {
        if (id == Guid.Empty)
        {
            return null;
        }

        return (TId?)(Activator.CreateInstance(typeof(TId), id) ?? null);
    }
}
