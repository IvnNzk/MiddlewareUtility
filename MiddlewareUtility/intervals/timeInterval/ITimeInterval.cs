namespace MiddlewareUtility.intervals.timeInterval
{
    using System;

    public interface ITimeInterval
    {
        DateTime DateTimeStart { get;  }
        DateTime DateTimeEnd { get; }
    }
}