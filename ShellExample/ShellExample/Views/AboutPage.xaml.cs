namespace ShellExample.Views;

public partial class AboutPage : BaseContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        App.Analytics.TrackEvent($"{ClassName}.{nameof(OnAppearing)}");

        base.OnAppearing();
    }
}