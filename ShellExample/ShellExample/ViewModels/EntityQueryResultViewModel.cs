using ShellExample.Models;

namespace ShellExample.ViewModels;

public class EntityQueryResultViewModel
{
    private readonly string _beforeString;
    private readonly string _queryString;
    private readonly string _afterString;

    public string BeforeString => _beforeString;
    public string QueryString => _queryString;
    public string AfterString => _afterString;

    public Entity Entity { get; }

    public EntityQueryResultViewModel(Entity entity, string queryString)
    {
        Entity = entity;

        _queryString = queryString;
        _beforeString = entity.FullText.Before(queryString, 40, StringComparison.OrdinalIgnoreCase);
        if (!string.IsNullOrEmpty(_beforeString))
        {
            _beforeString = $"...{_beforeString}";
        }

        _afterString = entity.FullText.After(queryString, 40, StringComparison.OrdinalIgnoreCase);
        if (!string.IsNullOrEmpty(_afterString))
        {
            _afterString += "...";
        }
    }
}