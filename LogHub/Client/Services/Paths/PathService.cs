using MudBlazor;

namespace Client.Services.Paths;

public class PathService : IPathService
{
    public List<BreadcrumbItem> Items { get; } = new();

    public void AddPath(string name, string path)
    {
        Items.Add(new BreadcrumbItem(name, path));
        NotifyStateChanged();
    }

    public void ReturnToPath(BreadcrumbItem item)
    {
        var index = Items.FindIndex(x => x == item);
        if (index == -1)
        {
            return;
        }

        Items.RemoveRange(index + 1, Items.Count - index - 1);
        NotifyStateChanged();
    }

    public void Clear()
    {
        Items.Clear();
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
