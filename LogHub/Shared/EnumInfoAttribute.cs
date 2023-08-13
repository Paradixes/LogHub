namespace Shared;

public class EnumInfoAttribute : Attribute
{
    public EnumInfoAttribute(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }
    public string Description { get; }
}
