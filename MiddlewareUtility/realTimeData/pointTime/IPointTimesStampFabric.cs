namespace MiddlewareUtility.realTimeData.pointTime
{
    using System;

    public interface IPointTimesStampFabric
    {
        IPointTimeStamp GetPointTime(DateTime time);
    }
}