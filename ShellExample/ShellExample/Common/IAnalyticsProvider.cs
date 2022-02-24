using ShellExample.Models;

namespace ShellExample.Common
{
    public interface IAnalyticsProvider
    {
        public void TrackError(Exception ex, Dictionary<string, string> messages = null);

        public void TrackEvent(string eventName, Entity entity, Favorite favorite);

        public void TrackEvent(string eventName, Dictionary<string, string> messages = null);
    }
}
