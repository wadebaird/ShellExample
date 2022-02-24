using Acr.UserDialogs;
using ShellExample.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShellExample.ViewModels;

public abstract class ItemsBaseViewModel<T> : BaseViewModel
{
    private bool _isInitialized;
    protected bool IsInitialized
    {
        get => _isInitialized;
        set 
        { 
            SetProperty(ref _isInitialized, value); 
            OnPropertyChanged(nameof(WereNoResultsFound));
        }
    }

    public bool WereNoResultsFound => IsInitialized && Items.Count == 0;

    private ObservableCollection<T> _items;
    public ObservableCollection<T> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }

    public ItemsBaseViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        Items = new ObservableCollection<T>();
    }

    protected abstract Task<IEnumerable<T>> LoadItems();

    public async Task ExecuteLoadItems()
    {
        Analytics.TrackEvent($"{ClassName}.{nameof(ExecuteLoadItems)}");
        IsBusy = true;

        try
        {
            using (UserDialogs.Instance.Loading(UiConstants.Loading))
            {
                Items.Clear();
                var items = await LoadItems();
                if (items != null)
                {
                    //Need to use an intemediary ObservableCollection here as loading it to the one attached to the view takes 20 seconds.
                    ObservableCollection<T> newItems = new();
                    newItems.AddRange(items);
                    Items = newItems;
                }
                IsInitialized = true;
            }
        }
        catch (Exception ex)
        {
            Analytics.TrackError(ex);
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public virtual async Task OnAppearing()
    {
        Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        if (!IsInitialized)
        {
            await ExecuteLoadItems();
        }
    }
}