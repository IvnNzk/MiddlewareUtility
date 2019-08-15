namespace MiddlewareUtility.Factories
{
    using System;
    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;
    
    public class DayIntervalFactory : IDayIntervalFactory
    {
        private readonly IUtilityLogger _logger;
        
        public static int MaxOffset { get; } = 86399000;
        public static int MinOffset { get; } = 0;

        public TimeInterval GetDayIntervalByDate(DateTime time, int offset)
        {
            if(time.Kind == DateTimeKind.Unspecified) throw  new ArgumentException("Time must be Utc or Local.");
            throw new NotImplementedException();
        }
    }
}