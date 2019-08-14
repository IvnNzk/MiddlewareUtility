namespace MiddlewareUtility.Factories
{
    using System;

    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;
    
    

    public class DayIntervalFactory : IDayIntervalFactory
    {
        private readonly IUtilityLogger _logger;


        public int DayDiff { get; }
        public IDayInterval GetDayIntervalByUtcTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public IDayInterval GetDayIntervalByLocalTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public IDayInterval GetLocalDayIntervalByUtcTime(DateTime time)
        {
            throw new NotImplementedException();
        }

        public IDayInterval GetLocalDayIntervalByLocalTime(DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}