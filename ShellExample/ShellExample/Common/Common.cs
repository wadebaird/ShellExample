namespace ShellExample.Common;

public static class Common
{
    public const string DateTimeFormat = "yyyy/MM/dd";

    public static int MonthDayYearToId(int month, int day, int year)
    {
        //Combine the 3 values into a single int with structure:
        //bits: 31       15       7       0
        //         year     Month    Day
        uint u32 = (uint)month << 8 | (uint)year << 16 | (uint)day;
        return (int)u32;
    }
}