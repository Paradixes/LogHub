using MudBlazor;

namespace Client.Services.Paths;

public interface IPathService
{
    public List<BreadcrumbItem> Items { get; }

    void AddPath(string name, string path);

    void ReturnToPath(BreadcrumbItem item);

    void Clear();

    event Action OnChange;
}
