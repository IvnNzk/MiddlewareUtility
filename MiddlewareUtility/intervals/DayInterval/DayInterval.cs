namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Types;
    using System;

    public class DayInterval : IDayInterval
    {
        private DateTime _dateEnd;
        private DateTime _dateStart;
        private DateTimeKind _kind;
        private int _offset;
        //private TimeZoneInfo _timeZone;

        public DayInterval(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException("check for new ");
            _dateStart = dateStart;
            _dateEnd = dateEnd;
            _kind = DateTimeKind.Unspecified;
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

        public DateTimeKind Kind
        {
            get => _kind;
        }
        
        public int Offset { get; }


        public ITimeInterval ToLocalTimeInterval()
        {
            throw new NotImplementedException("Should return new instance with kind");
        }

        public ITimeInterval ToUtcTimeInterval()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString() => $"DayInterval {_dateStart}-{_dateEnd}";
    }
}