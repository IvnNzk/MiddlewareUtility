using System;
using MiddlewareUtility.Tools;

namespace MiddlewareUtility.Types
{
    public class TimeInterval : ITimeInterval
    {
        private DateTime _dateEnd;
        private DateTime _dateStart;
        private DateTimeKind _kind;

        public DateTime DateTimeEnd
        {
            get => _dateEnd;
        }

        public DateTime DateTimeStart
        {
            get => _dateStart;
        }

        public DateTimeKind Kind
        {
            get => _kind;
        }

        public TimeInterval(DateTime dateStart, DateTime dateEnd)
        {
            this._dateStart = dateStart;
            this._dateEnd = dateEnd;
            throw new NotImplementedException("_kind");
        }

        public ITimeInterval ToLocalTimeInterval()
        {
            throw new NotImplementedException();
        }

        public ITimeInterval ToUtcTimeInterval()
        {
            throw new NotImplementedException();
        }
    }
}