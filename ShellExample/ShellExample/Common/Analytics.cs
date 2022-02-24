using ShellExample.Models;

namespace ShellExample.Common;

internal class Analytics : IAnalyticsProvider
{
    public void TrackError(Exception ex, Dictionary<string, string> messages = null)
    {
        if (null == messages)
        {
            messages = new();
        }

        Microsoft.AppCenter.Crashes.Crashes.TrackError(ex, messages);
    }

    public void TrackEvent(string eventName, Entity entity, Favorite favorite)
    {
        TrackEvent(eventName, new()
        {
        });
    }

    public void TrackEvent(string eventName, Dictionary<string, string> messages = null)
    {
        if (null == messages)
        {
            messages = new();
        }

        Microsoft.AppCenter.Analytics.Analytics.TrackEvent(eventName, messages);
    }
}