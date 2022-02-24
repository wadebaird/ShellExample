using ShellExample.ViewModels;

namespace ShellExample.Views;

public partial class EntitysListPage : BaseContentPage
{
    private readonly EntitysListViewModel _viewModel;

    public EntitysListPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new EntitysListViewModel(null, App.Analytics);
    }

    protected override async void OnAppearing()
    {
        App.Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        base.OnAppearing();
        await _viewModel.OnAppearing();
    }
}