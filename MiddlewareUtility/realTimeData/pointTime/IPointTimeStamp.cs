namespace MiddlewareUtility.realTimeData.pointTime
{
    using System;

    public interface IPointTimeStamp
    {
        DateTime LocalTime { get; }
    }
}