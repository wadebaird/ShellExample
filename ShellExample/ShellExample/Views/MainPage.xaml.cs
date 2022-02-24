using ShellExample.Common;
using ShellExample.ViewModels;
using Xamarin.Forms;

namespace ShellExample.Views;

public partial class MainPage : BaseContentPage
{
    private const int FadeMilliSeconds = 250;
    private readonly MainPageViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _viewModel = new MainPageViewModel(null, App.Analytics);
    }

    protected override void OnAppearing()
    {
        App.Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        base.OnAppearing();
    }

    private void Swipe(object sender, SwipedEventArgs e)
    {
    }
}