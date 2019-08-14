namespace MiddlewareUtility.Tools
{
    using System;
    using System.ComponentModel;
    using MiddlewareUtility.Types;

    [ImmutableObject(true)]
    public class DayInterval : TimeInterval, IDayInterval
    {
        public static int MaxOffset { get; } = 86399000;
        public static int MinOffset { get; } = 0;

        private int _offset;

        public DayInterval(DateTime dateStart, DateTime dateEnd, int offset)
            : base(dateStart, dateStart)
        {
            throw new NotImplementedException("check for new");
            _offset = offset;
        }

        public int Offset
        {
            get => _offset;
        }

        public bool ValidateDayInterval
        {
            get { throw new NotImplementedException("startTime - endTime = 24 hours"); }
        }

        public ITimeInterval ToLocalTimeInterval()
        {
            throw new NotImplementedException("Should return new instance with kind");
        }

        public ITimeInterval ToUtcTimeInterval()
        {
            throw new NotImplementedException("Should return new instance with kind");
        }

        public override string ToString() => $"DayInterval {this.DateTimeStart}-{this.DateTimeEnd}";
    }
}