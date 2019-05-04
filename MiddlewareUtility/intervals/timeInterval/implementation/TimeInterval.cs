namespace MiddlewareUtility.intervals.timeInterval.implementation
{
    using System;

    public class TimeInterval : ITimeInterval
    {
        public TimeInterval()
        {
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