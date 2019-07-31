namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Types;
    using System;

    public interface IDayIntervalFactory
    {
        int DayDiff { get; }

        IDayInterval GetDayIntervalByUtcTime(DateTime time);
    }
}