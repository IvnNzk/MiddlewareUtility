namespace MiddlewareUtility.intervals.dayIntervals
{
    using System;
    using MiddlewareUtility.intervals.timeInterval;

    public interface IDayInterval : ITimeInterval
    {
        TimeZoneInfo CurrentTimeZoneInfo { get; }
    }
}