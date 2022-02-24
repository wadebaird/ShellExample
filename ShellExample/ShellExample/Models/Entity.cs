using SQLite;

namespace ShellExample.Models;

public class Entity : MonthDayYearEntity
{
    [Ignore]
    public DateTime Date => new(App.LeapYearToUse, Month, Day);

    public string Phase1 { get; set; }
    public string Phase2 { get; set; }
    public string Phase3 { get; set; }
    public string Phase4 { get; set; }
    public string Phase5 { get; set; }

    public string FullText { get; set; }

    public (string Title, string Text) TextForSharing()
    {
        return ($"{Date:M} - {Phase1}", "Body");
    }
}