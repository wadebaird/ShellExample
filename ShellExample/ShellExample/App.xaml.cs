using ShellExample.Common;
using Xamarin.Forms;

namespace ShellExample;

public partial class App : Application
{
    public static IAnalyticsProvider Analytics = new Analytics();
    public static readonly int LeapYearToUse = GetNextLeapYear();

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
    }

    protected override void OnResume()
    {
        base.OnResume();
    }

    private static int GetNextLeapYear()
    {
        int year = DateTime.Now.Year - 1;
        while (!DateTime.IsLeapYear(++year));

        return year;
    }

    public static T FindResource<T>(string resourceKey)
    {
        if (string.IsNullOrEmpty(resourceKey))
            throw new ArgumentException(nameof(resourceKey));

        if (!Application.Current.Resources.TryGetValue(resourceKey, out object resource))
        {
            foreach (var dict in Application.Current.Resources.MergedDictionaries)
            {
                if(dict.TryGetValue(resourceKey, out resource))
                    break;
            }
        }

        return (T)resource;
    }
}