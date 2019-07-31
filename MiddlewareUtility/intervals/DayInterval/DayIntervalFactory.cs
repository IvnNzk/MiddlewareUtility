namespace MiddlewareUtility.Factories
{
    using System;

    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;

    public class DayIntervalFactory : IDayIntervalFactory
    {
        private readonly int _dayDiff;
        private readonly int _dayDiffLocal;
        private readonly IUtilityLogger _logger;

        public DayIntervalFactory()
        {
            _dayDiff = 0;
            _logger = new DefaultLogger();
        }

        public DayIntervalFactory(int dayDiffMilliseconds)
        {
            _dayDiff = dayDiffMilliseconds;
            _logger = new DefaultLogger();
        }

        public DayIntervalFactory(IUtilityLogger logger)
        {
            _logger = logger;
            _dayDiff = 0;
        }

        public DayIntervalFactory(IUtilityLogger logger, int dayDiffMilliseconds)
        {
            _logger = logger;
            _dayDiff = dayDiffMilliseconds;
        }

        public int DayDiff => _dayDiff;
        public IDayInterval GetDayIntervalByUtcTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public IUtilityLogger Logger => _logger;

        public IDayInterval GetDayIntervalByUtcTime_returnUtcFormat(DateTime time)
        {
            if (DateTimeKind.Utc != time.Kind)
            {
                throw new ArgumentException("time variable must be a Utc only");
            }

            DateTime timeStamp1; // = new DateTime(time.Year,time.Month,time.Day,0,0,0,DateTimeKind.Utc);

            if (time.Kind == DateTimeKind.Local)
            {
                var utcTime = time.ToUniversalTime();
                timeStamp1 = new DateTime(utcTime.Year, utcTime.Month, utcTime.Day, 0, 0, 0, DateTimeKind.Utc);
            }
            else
            {
                timeStamp1 = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0, DateTimeKind.Utc);
            }

            if (_dayDiff != 0)
            {
                timeStamp1 = timeStamp1.AddMilliseconds(_dayDiff);
            }

            DateTime timeStamp2;
            IDayInterval interval;

            if (time >= timeStamp1)
            {
                timeStamp2 = timeStamp1.AddDays(1).AddSeconds(-1);
                interval = new DayInterval(timeStamp1, timeStamp2);
            }
            else
            {
                timeStamp2 = timeStamp1.AddDays(-1);
                timeStamp1 = timeStamp1.AddSeconds(-1);
                interval = new DayInterval(timeStamp2, timeStamp1);
            }

            return interval;
        }

        public IDayInterval GetDayIntervalByUtcTime_returnLocalFormat(DateTime time)
        {
            if (DateTimeKind.Utc != time.Kind)
            {
                throw new ArgumentException("time variable must be a Utc only");
            }
            
            throw new NotImplementedException("need refactor this...");

            IDayInterval interval;
            return interval;
        }

        public IDayInterval GetDayIntervalByLocalTime_returnLocalFormat(DateTime time)
        {
            if (DateTimeKind.Local != time.Kind)
            {
                throw new ArgumentException("time variable must be a Local only");
            }

            IDayInterval interval;
            return interval;
        }

        public IDayInterval GetDayIntervalByLocalTime_returnUtcFormat(DateTime time)
        {
            if (DateTimeKind.Local != time.Kind)
            {
                throw new ArgumentException("time variable must be a Local only");
            }

            IDayInterval interval;
            return interval;
        }
    }
}