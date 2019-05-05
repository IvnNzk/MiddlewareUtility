namespace MiddlewareUtility_test.intervals.dayIntervals.implementation
{
    using System;
    using System.Globalization;
    using LoggerLib.logging;
    using LoggerLib.logging.implementation;
    using MiddlewareUtility.intervals.dayIntervals.implementation;
    using NUnit.Framework;

    [TestFixture]
    public class DayIntervalFabricTestIntervalsFunctions
    {
        private static IUtilityLogger _logger;
        private static DayIntervalFabric _fabric;
        private static string _format;
        private static CultureInfo _provider;

        static DayIntervalFabricTestIntervalsFunctions()
        {
            _logger = new ConsoleLogger();
            _fabric = new DayIntervalFabric();
            _format = "yyyy-MM-dd HH:mm:ss,fff";
            _provider = CultureInfo.CurrentUICulture;
        }

        public void GetDayIntervalByUtcTimeTest()
        {
            throw new NotImplementedException();
        }
    }
}