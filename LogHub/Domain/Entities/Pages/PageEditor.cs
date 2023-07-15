using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public class PageEditor : Entity<PageEditorId>
{
    private PageEditor() { }

    internal PageEditor(PageId pageId, UserId userId)
    {
        PageId = pageId;
        UserId = userId;
    }

    public PageId PageId { get; private set; }

    public UserId UserId { get; private set; }
}
