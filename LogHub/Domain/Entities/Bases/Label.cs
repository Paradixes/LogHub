using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Bases;

public class Label : Entity<LabelId>
{
    private Label() { }

    internal Label(BaseId baseId, string name, string color)
    {
        BaseId = baseId;
        Name = name;
        Color = color;
    }

    public BaseId BaseId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string Color { get; private set; } = null!;


    public void Update(string name, string color)
    {
        Name = name;
        Color = color;
    }
}
