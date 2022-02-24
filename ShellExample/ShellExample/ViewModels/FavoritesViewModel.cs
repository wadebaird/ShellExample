using ShellExample.Common;
using ShellExample.Models;
using Xamarin.Forms;

namespace ShellExample.ViewModels;

public class FavoritesViewModel : ItemsTappableBaseViewModel<Favorite>
{
    public Command LoadItemsCommand { get; }

    public FavoritesViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        Title = "Favorites";
        
        LoadItemsCommand = new Command(() =>
        {
        });
    }

    protected override void ItemTapped(Favorite favorite)
    {
    }

    protected override Task<IEnumerable<Favorite>> LoadItems()
    {
        return Task.FromResult<IEnumerable<Favorite>>(new List<Favorite>());
    }
}