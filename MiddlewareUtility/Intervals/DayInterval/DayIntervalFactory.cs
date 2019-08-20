namespace MiddlewareUtility.Factories
{
    using System;
    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;

    public class DayIntervalFactory : IDayIntervalFactory
    {
        private readonly IUtilityLogger _logger;

        public static int MaxOffset { get; } = 86398000;
        public static int MinOffset { get; } = 0;

        public DayIntervalFactory()
        {
            _logger = new DefaultLogger();
        }

        public DayIntervalFactory(IUtilityLogger logger)
        {
            _logger = logger;
        }

        public TimeInterval GetDayIntervalByDate(DateTime time, int offset)
        {
            if (time.Kind == DateTimeKind.Unspecified) throw new ArgumentException(DayIntervalFactoryMessages.TIME_IN_UNSPECIFIED);
            if (offset > MaxOffset) throw  new ArgumentException(DayIntervalFactoryMessages.OFFSET_MORE_THEN_MAXVALUE);
            if (offset < MinOffset) throw  new ArgumentException(DayIntervalFactoryMessages.OFFSET_LESS_THEN_MINVALUE);

            var currentKind = time.Kind;
            var midnightTime = new DateTime(time.Year,time.Month,time.Day,0,0,0,0,currentKind);

            var boundaryTime = midnightTime.AddMilliseconds(offset);

            DateTime startTime;
            DateTime endTime;

            if (boundaryTime <= time)
            {
                startTime = boundaryTime;
                endTime = boundaryTime.AddDays(1).AddSeconds(-1);
            }
            else
            {
                startTime = boundaryTime.AddDays(-1);
                endTime = boundaryTime.AddSeconds(-1);
            }
            return new TimeInterval(startTime,endTime);
        }
    }
}