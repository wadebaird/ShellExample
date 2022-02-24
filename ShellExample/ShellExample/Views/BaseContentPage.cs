using System.Windows.Input;
using Xamarin.Forms;

namespace ShellExample.Views;

public abstract class BaseContentPage : Sunbreak.Common.Xamarin.Views.BaseContentPage
{
    public ICommand HyperlinkCommand => new Command<string>(async (url) =>
    {
        try
        {
            await Xamarin.Essentials.Launcher.OpenAsync(url);
        }
        catch (Exception ex)
        {
            App.Analytics.TrackError(ex);
            await DisplayAlert("Error", "Error in loading web url. Please inform technical support.", "Ok");
        }
    });

    public BaseContentPage()
    {
    }
}