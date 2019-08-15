namespace MiddlewareUtility.Factories
{
    using System;
    using MiddlewareUtility.Tools;

    public interface IDayIntervalFactory
    {
        TimeInterval GetDayIntervalByDate(DateTime time, int offset);
    }
}