using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Docs;

public class Document : RecordEntity
{
    private readonly List<DocEditor> _editors = new();

    private readonly List<DocLabel> _labels = new();

    private Document() { }

    internal Document(
        RecordId logbookId,
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

    public IReadOnlyCollection<DocEditor> Editors => _editors.AsReadOnly();

    public IReadOnlyCollection<DocLabel> Labels => _labels.AsReadOnly();

    public RecordId LogbookId { get; private set; } = null!;

    public string? Content { get; private set; }

    public DocStatus Status { get; private set; }

    public override RecordType RecordType { get; protected init; } = RecordType.Document;

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
