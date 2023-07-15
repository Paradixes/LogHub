using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public class ProjectAction : Entity<ProjectActionId>, IAuditableEntity
{
    private ProjectAction() { }

    internal ProjectAction(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}
