using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public class ProjectRequest : Entity<ProjectRequestId>, IAuditableEntity
{
    private ProjectRequest() { }

    internal ProjectRequest(ProjectId projectId, UserId handlerId, string title, string description)
    {
        Id = new ProjectRequestId(Guid.NewGuid());
        ProjectId = projectId;
        HandlerId = handlerId;
        Title = title;
        Description = description;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public ProjectId ProjectId { get; private set; }

    public UserId HandlerId { get; private set; }

    public bool IsAccepted { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public void Accept()
    {
        if (!IsAccepted)
        {
            IsAccepted = true;
            Raise(new ProjectRequestAcceptedDomainEvent(Guid.NewGuid(), Id));
        }
    }
}
