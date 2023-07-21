using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Bases;

public class Label : Entity<LabelId>
{
    private Label() { }

    internal Label(RecordId recordId, string name, string color)
    {
        RecordId = recordId;
        Name = name;
        Color = color;
    }

    public RecordId RecordId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string Color { get; private set; } = null!;


    public void Update(string name, string color)
    {
        Name = name;
        Color = color;
    }
}
