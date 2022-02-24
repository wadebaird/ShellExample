using ShellExample.Common;
using ShellExample.Models;

namespace ShellExample.ViewModels;

public class EntitysListViewModel : ItemsTappableBaseViewModel<Entity>
{
    public EntitysListViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        Title = "Select an Entity";
    }

    protected override void ItemTapped(Entity t)
    {
    }

    protected override Task<IEnumerable<Entity>> LoadItems()
    {
        return Task.FromResult<IEnumerable<Entity>>(new List<Entity>());
    }
}