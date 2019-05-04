namespace MiddlewareUtility.intervals.dayIntervals
{
    using MiddlewareUtility.intervals.timeInterval;

    public interface IDayInterval : ITimeInterval
    {
        int DayDiff { get; }
    }
}