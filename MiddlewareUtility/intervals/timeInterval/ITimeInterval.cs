namespace MiddlewareUtility.intervals.timeInterval
{
    using System;

    public interface ITimeInterval
    {
        DateTime DateTimeStart { get; set; }
        DateTime DateTimeEnd { get; set; }
    }
}