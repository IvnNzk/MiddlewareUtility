namespace MiddlewareUtility.intervals.dayIntervals
{
    using System;

    public interface IDayIntervalFabric
    {
        IDayInterval GetDayIntervalByUtcTime(DateTime time);
        int DayDiff { get; }
    }
}