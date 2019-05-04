namespace MiddlewareUtility.intervals.timeInterval.implementation
{
    using LoggerLib.logging;
    using LoggerLib.logging.implementation;

    public class TimeIntervalFabric : ITimeIntervalFabric
    {
        private IUtilityLogger _logger;

        public TimeIntervalFabric()
        {
            _logger = new ConsoleLogger();
        }

        public TimeIntervalFabric(IUtilityLogger logger)
        {
            _logger = logger;
        }
    }
}