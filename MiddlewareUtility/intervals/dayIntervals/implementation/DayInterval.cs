namespace MiddlewareUtility.intervals.dayIntervals.implementation
{
    using System;

    public class DayInterval : IDayInterval
    {
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private TimeZoneInfo _timeZone;

        public DayInterval()
        {
            throw new ArgumentException("DayInterval instance should create by constructor with parameters");
        }

        public DayInterval(DateTime dateStart, DateTime dateEnd)
        {
            _dateStart = dateStart;
            _dateEnd = dateEnd;
            _timeZone = TimeZoneInfo.Local;
        }

        public DayInterval(DateTime dateStart, DateTime dateEnd, TimeZoneInfo timeZone)
        {
            _dateStart = dateStart;
            _dateEnd = dateEnd;
            _timeZone = timeZone;
        }

        public DateTime DateTimeStart
        {
            get => _dateStart;
            private set => _dateStart = value;
        }

        public DateTime DateTimeEnd
        {
            get => _dateEnd;
            private set => _dateEnd = value;
        }

        public TimeZoneInfo CurrentTimeZoneInfo
        {
            get => _timeZone;
            private set => _timeZone = value;
        }

        public override string ToString() => $"DayInterval {_dateStart}-{_dateEnd}";
    }
}