using ShellExample.Common;
using ShellExample.Models;
using Xamarin.Forms;

namespace ShellExample.ViewModels;

public abstract class BaseViewModel : Sunbreak.Common.Xamarin.ViewModels.BaseViewModel
{
    protected IDataStoreService DataStore { get; }

    protected IAnalyticsProvider Analytics { get; }

    public BaseViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics)
    {
        DataStore = dataStore;
        Analytics = analytics;
    }

    protected Task NavigateTo(DateTime date)
    {
        return Task.CompletedTask;
    }

    protected Task NavigateTo(Entity entity, Favorite favorite = null)
    {
        return Task.CompletedTask;
    }
}