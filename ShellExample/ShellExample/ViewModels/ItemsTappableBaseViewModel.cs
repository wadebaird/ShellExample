using ShellExample.Common;
using Xamarin.Forms;

namespace ShellExample.ViewModels;

public abstract class ItemsTappableBaseViewModel<T> : ItemsBaseViewModel<T>
{
    public Command<T> ItemTappedCommand { get; }

    public ItemsTappableBaseViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        ItemTappedCommand = new Command<T>(ItemTapped);
    }

    protected abstract void ItemTapped(T t);
}