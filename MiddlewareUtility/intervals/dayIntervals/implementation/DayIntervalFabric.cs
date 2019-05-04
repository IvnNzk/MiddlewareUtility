namespace MiddlewareUtility.intervals.dayIntervals.implementation
{
    using System;
    using LoggerLib.logging;
    using LoggerLib.logging.implementation;

    public class DayIntervalFabric : IDayIntervalFabric
    {
        private IUtilityLogger _logger;

        public DayIntervalFabric()
        {
            _logger = new ConsoleLogger();
        }

        public DayIntervalFabric(IUtilityLogger logger)
        {
            _logger = logger;
        }

        public IDayInterval GetDayIntervalByTime(DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}