namespace MiddlewareUtility.Types
{
    using System;

    public interface IDayInterval : ITimeInterval
    {
        //TimeZoneInfo CurrentTimeZoneInfo { get; }
        int Offset { get; }
    }
}