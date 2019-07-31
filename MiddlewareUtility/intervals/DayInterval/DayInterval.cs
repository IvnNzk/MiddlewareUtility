namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Types;
    using System;

    public class DayInterval : IDayInterval
    {
        private DateTime _dateEnd;
        private DateTime _dateStart;
        private TimeZoneInfo _timeZone;

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

        public TimeZoneInfo CurrentTimeZoneInfo
        {
            get => _timeZone;
            private set => _timeZone = value;
        }

        public DateTime DateTimeEnd
        {
            get => _dateEnd;
            private set => _dateEnd = value;
        }

        public DateTime DateTimeStart
        {
            get => _dateStart;
            private set => _dateStart = value;
        }

        public override string ToString() => $"DayInterval {_dateStart}-{_dateEnd}";
    }
}