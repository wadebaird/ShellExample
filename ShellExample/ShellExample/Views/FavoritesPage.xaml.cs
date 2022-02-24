using ShellExample.ViewModels;

namespace ShellExample.Views;

public partial class FavoritesPage : BaseContentPage
{
    private readonly FavoritesViewModel _viewModel;

    public FavoritesPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new FavoritesViewModel(null, App.Analytics);
    }

    protected override async void OnAppearing()
    {
        App.Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        base.OnAppearing();
        await _viewModel.OnAppearing();
    }
}