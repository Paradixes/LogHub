using LogHub.Domain.DomainEvents.Pages;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public class Page : Entity<PageId>, IRecordEntity
{
    private readonly List<PageEditor> _editors = new();

    private readonly List<PageLabel> _labels = new();

    private Page() { }

    public IReadOnlyCollection<PageEditor> Editors => _editors.AsReadOnly();

    public IReadOnlyCollection<PageLabel> Labels => _labels.AsReadOnly();

    public LogbookId LogbookId { get; private set; }

    public string? Content { get; private set; }

    public PageStatus Status { get; private set; }

    public UserId CreatorId { get; private set; }

    public string Title { get; private set; }

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static Page Create(UserId creatorId, LogbookId logbookId, string title, string? icon, string? description,
        string? content)
    {
        var page = new Page
        {
            Id = new PageId(Guid.NewGuid()),
            CreatorId = creatorId,
            LogbookId = logbookId,
            Title = title,
            Icon = icon,
            Description = description,
            Content = content,
            Status = PageStatus.Active
        };

        page.Raise(new PageCreatedDomainEvent(
            Guid.NewGuid(),
            page.Id,
            page.CreatorId));

        return page;
    }

    public void UpdateDetails(string title, string? icon, string? description)
    {
        if (Title != title || Icon != icon || Description != description)
        {
            Raise(new PageDetailsUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Title = title;
        Icon = icon;
        Description = description;
    }

    public void UpdateContent(string content)
    {
        if (Content != content)
        {
            Raise(new PageContentUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Content = content;
    }

    public void UpdateStatus(PageStatus status)
    {
        if (Status == status)
        {
            return;
        }

        Status = status;
        Raise(new PageStatusUpdatedDomainEvent(Guid.NewGuid(), Id));
    }

    public void AddEditor(UserId userId)
    {
        if (_editors.Any(x => x.UserId == userId))
        {
            return;
        }

        var editor = new PageEditor(Id, userId);
        _editors.Add(editor);
    }

    public void AddLabel(LabelId labelId)
    {
        if (_labels.Any(x => x.LabelId == labelId))
        {
            return;
        }

        var label = new PageLabel(Id, labelId);
        _labels.Add(label);
    }

    public void RemoveLabel(LabelId labelId)
    {
        var label = _labels.FirstOrDefault(x => x.LabelId == labelId);
        if (label is null)
        {
            return;
        }

        _labels.Remove(label);
    }
}
