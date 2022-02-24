using SQLite;

namespace ShellExample.Models;

public class MonthDayYearEntity
{
    [PrimaryKey, Indexed]
    public int Id { get; set; }

    public int Month
    {
        get => (byte)(Id >> 8);
        set
        {
            Id = Common.Common.MonthDayYearToId(value, Day, Year);
        }
    }

    public int Day
    {
        get => (byte)Id;
        set
        {
            Id = Common.Common.MonthDayYearToId(Month, value, Year);
        }
    }

    public int Year
    {
        get => (short)(Id >> 16);
        set
        {
            Id = Common.Common.MonthDayYearToId(Month, Day, value);
        }
    }

    public MonthDayYearEntity()
    {
    }
}
