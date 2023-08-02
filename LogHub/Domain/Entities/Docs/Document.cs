using Domain.Entities.Bases;
using Domain.Entities.Logbooks;
using Domain.Entities.Users;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Docs;

public class Document : RecordEntity<DocumentId, DocActionId, DocPermissionId, DocRequestId>
{
    private readonly List<DocEditor> _editors = new();

    private readonly List<DocLabel> _labels = new();

    private Document() { }

    internal Document(
        LogbookId logbookId,
        string title,
        string? icon,
        string? description,
        string? content,
        DocStatus status,
        UserId creatorId)
        : base(creatorId, title, icon, description)
    {
        LogbookId = logbookId;
        Content = content;
        Status = status;
    }

    public IEnumerable<DocEditor> Editors => _editors.AsReadOnly();

    public IEnumerable<DocLabel> Labels => _labels.AsReadOnly();

    public LogbookId LogbookId { get; private set; } = null!;

    public string? Content { get; private set; }

    public DocStatus Status { get; private set; }

    public void UpdateContent(string content)
    {
        Content = content;
    }

    public void UpdateStatus(DocStatus status)
    {
        Status = status;
    }

    public void AddEditor(UserId userId)
    {
        if (_editors.Any(x => x.UserId == userId))
        {
            return;
        }

        var editor = new DocEditor(Id, userId);
        _editors.Add(editor);
    }

    public void AddLabel(LabelId labelId)
    {
        if (_labels.Any(x => x.LabelId == labelId))
        {
            return;
        }

        var label = new DocLabel(Id, labelId);
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