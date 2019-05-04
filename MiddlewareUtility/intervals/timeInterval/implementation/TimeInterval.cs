namespace MiddlewareUtility.intervals.timeInterval.implementation
{
    using System;

    public class TimeInterval : ITimeInterval
    {
        public TimeInterval()
        {
            throw new ArgumentException("TimeInterval instance should create by constructor with parameters");
        }

        public TimeInterval(DateTime dateStart, DateTime dateEnd)
        {
            DateTimeStart = dateStart;
            DateTimeEnd = dateEnd;
        }

        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}