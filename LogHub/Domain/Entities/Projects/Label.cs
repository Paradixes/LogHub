using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public class Label : Entity<LabelId>
{
    private Label() { }

    internal Label(ProjectId projectId, string name, string color)
    {
        Id = new LabelId(Guid.NewGuid());
        ProjectId = projectId;
        Name = name;
        Color = color;
    }

    public ProjectId ProjectId { get; private set; }

    public string Name { get; private set; }

    public string Color { get; private set; }


    public void Update(string name, string color)
    {
        if (Name == name && Color == color)
        {
            return;
        }

        Name = name;
        Color = color;
    }
}
