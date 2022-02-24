using ShellExample.Common;
using ShellExample.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellExample.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private Favorite _favorite;

    public ICommand SetFavoriteCommand { get; }
    public ICommand LoadTodaysEntityCommand { get; }
    public ICommand ShareCurrentEntityCommand { get; }

    public Favorite Favorite
    {
        get => _favorite;
        private set
        {
            SetProperty(ref _favorite, value);

            //Trigger the UI to refresh for the Favorite Icon
            OnPropertyChanged(nameof(FontImageSource));
        }
    }

    public FontImageSource FontImageSource => new() 
    { 
        Size = App.FindResource<double>("ToolbarIconSize"),
        Glyph = FontAwesome.FontAwesomeIcons.Star, 
        FontFamily = FavoriteStarFontFamily,
    };

    public string FavoriteStarFontFamily
    {
        get => _favorite == null ? "FA-Regular" : "FA-Solid";
    }

    public MainPageViewModel(IDataStoreService dataStore, IAnalyticsProvider analytics) : base(dataStore, analytics)
    {
        SetFavoriteCommand = new Command(() =>
        {
        });

        LoadTodaysEntityCommand = new Command(() =>
        {
        });

        ShareCurrentEntityCommand = new Command(() =>
        {
        });
    }
}