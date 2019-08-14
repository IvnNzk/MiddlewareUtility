namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Types;
    using System;

    public interface IDayIntervalFactory
    {
        int DayDiff { get; }

        IDayInterval GetDayIntervalByUtcTime(DateTime time);
        IDayInterval GetDayIntervalByLocalTime(DateTime time);

        IDayInterval GetLocalDayIntervalByUtcTime(DateTime time);

        IDayInterval GetLocalDayIntervalByLocalTime(DateTime time);

    }
}