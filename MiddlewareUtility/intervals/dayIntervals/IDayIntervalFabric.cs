namespace MiddlewareUtility.intervals.dayIntervals
{
    using System;

    public interface IDayIntervalFabric
    {
        IDayInterval GetDayIntervalByTime(DateTime time);
    }
}