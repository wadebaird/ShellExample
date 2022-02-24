using ShellExample.Common;
using Xamarin.Forms;

namespace ShellExample.ViewModels;

public class EntitysCalendarViewModel : BaseViewModel
{
    private DateTime? _selectedDate = null;

    public EntitysCalendarViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        Title = "Select a Day";
    }

    public Command<DateTime> DayTappedCommand => new(async (date) =>
    {
        Analytics.TrackEvent($"{ClassName}.{nameof(DayTappedCommand)}", new()
        {
        });

        await NavigateTo(SelectedDate.Value);
    });

    public DateTime MonthYear => DateTime.Now;

    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set => SetProperty(ref _selectedDate, value);
    }

    public void OnAppearing()
    {
    }
}