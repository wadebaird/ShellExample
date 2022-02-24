using ShellExample.ViewModels;

namespace ShellExample.Views;

public partial class EntitysCalendarPage : BaseContentPage
{
    private readonly EntitysCalendarViewModel _viewModel;

    public EntitysCalendarPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new EntitysCalendarViewModel(null, App.Analytics);
    }

    protected override void OnAppearing()
    {
        App.Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}