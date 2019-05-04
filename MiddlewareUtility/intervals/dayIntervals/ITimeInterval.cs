
namespace MiddlewareUtility.intervals.dayIntervals
{
    using System;

    public interface ITimeInterval
    {
        DateTime DateTimeStart { get; set; }
        DateTime DateTimeEnd { get; set; }
    }
}