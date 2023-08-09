using Domain.Entities.Records.Repositories;
using Domain.Primitives;

namespace Domain.Entities.Records.Labels;

public class Label : Entity<LabelId>
{
    private Label() { }

    internal Label(RepositoryId repositoryId, string name, string color)
    {
        RepositoryId = repositoryId;
        Name = name;
        Color = color;
    }

    public RecordId RepositoryId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string Color { get; private set; } = null!;


    public void Update(string name, string color)
    {
        Name = name;
        Color = color;
    }
}
