using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public class FavouritePage : Entity<FavouritePageId>
{
    internal FavouritePage(UserId userId, PageId pageId)
    {
        UserId = userId;
        PageId = pageId;
    }

    private FavouritePage() { }

    public UserId UserId { get; set; }

    public PageId PageId { get; set; }
}
