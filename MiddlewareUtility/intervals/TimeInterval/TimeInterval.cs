using MiddlewareUtility.intervals.Tools;

namespace MiddlewareUtility.Tools
{
    using System;
    using System.ComponentModel;
    using MiddlewareUtility.Types;

    [ImmutableObject(true)]
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

            if (dateStart.Kind == DateTimeKind.Unspecified)
                throw new ArgumentException(TimeIntervalMessages.STARTTIME_IN_UNSPECIFIED);
            if (dateEnd.Kind == DateTimeKind.Unspecified)
                throw new ArgumentException(TimeIntervalMessages.ENDTIME_IN_UNSPECIFIED);
            if (dateEnd.Kind == dateStart.Kind)
                throw new ArgumentException(TimeIntervalMessages.KINDS_MUST_BE_THE_SAME);

            _dateStart = dateStart;
            _dateEnd = dateEnd;
            _kind = dateStart.Kind;
        }

        public ITimeInterval ToLocalTimeInterval()
        {
            throw new NotImplementedException();
        }

        public ITimeInterval ToUtcTimeInterval()
        {
            throw new NotImplementedException();
        }

        protected bool Equals(TimeInterval other)
        {
            return _dateEnd.Equals(other._dateEnd) && _dateStart.Equals(other._dateStart) && _kind == other._kind;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TimeInterval) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _dateEnd.GetHashCode();
                hashCode = (hashCode * 397) ^ _dateStart.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) _kind;
                return hashCode;
            }
        }
    }
}