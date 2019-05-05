namespace MiddlewareUtility.intervals.dayIntervals.implementation
{
    using System;
    using LoggerLib.logging;
    using LoggerLib.logging.implementation;

    public class DayIntervalFabric : IDayIntervalFabric
    {
        private IUtilityLogger _logger;
        private int _dayDiff;

        public DayIntervalFabric()
        {
            _logger = new ConsoleLogger();
            _dayDiff = 0;
        }

        public DayIntervalFabric(int dayDiffMilliseconds)
        {
            _logger = new ConsoleLogger();
            _dayDiff = dayDiffMilliseconds;
        }

        public DayIntervalFabric(IUtilityLogger logger)
        {
            _logger = logger;
            _dayDiff = 0;
        }

        public DayIntervalFabric(IUtilityLogger logger, int dayDiffMilliseconds)
        {
            _logger = new ConsoleLogger();
            _dayDiff = dayDiffMilliseconds;
        }

        public int DayDiff => _dayDiff;

        public IDayInterval GetDayIntervalByUtcTime(DateTime time)
        {
            if (DateTimeKind.Unspecified == time.Kind)
            {
                throw new ArgumentException("time variable must be a Utc or Local time");
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
    }
}