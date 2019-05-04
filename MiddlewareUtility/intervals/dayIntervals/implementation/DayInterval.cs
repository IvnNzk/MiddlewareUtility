namespace MiddlewareUtility.intervals.dayIntervals.implementation
{
    using System;

    public class DayInterval : IDayInterval
    {
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private int _dayDiff;

        public DayInterval()
        {
            throw new ArgumentException("DayInterval instance should create by constructor with parameters");
        }

        public DayInterval(DateTime dateStart, DateTime dateEnd, int dayDiff)
        {
            _dateStart = dateStart;
            _dateEnd = dateEnd;
            _dayDiff = _dayDiff;
        }

        public DateTime DateTimeStart
        {
            get => _dateStart;
            set => _dateStart = value;
        }

        public DateTime DateTimeEnd
        {
            get => _dateEnd;
            set => _dateEnd = value;
        }

        public int DayDiff
        {
            get => _dayDiff;
            set => _dayDiff = value;
        }

        public override string ToString() => $"DayInterval {_dateStart}-{_dateEnd}";
    }
}