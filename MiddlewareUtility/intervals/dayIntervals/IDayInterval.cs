using System;

namespace MiddlewareUtility.intervals.dayIntervals
{
    public interface IDayInterval
    {
        DateTime DateTimeStart { get; set; }
        DateTime DateTimeEnd { get; set; }
        int DayDiff { get; set; }
    }
}