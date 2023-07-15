using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public class PageLabel : Entity<PageLabelId>
{
    private PageLabel() { }

    internal PageLabel(PageId pageId, LabelId labelId)
    {
        Id = new PageLabelId(Guid.NewGuid());
        PageId = pageId;
        LabelId = labelId;
    }

    public PageId PageId { get; }

    public LabelId LabelId { get; }
}
