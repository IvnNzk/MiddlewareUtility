using System;
using MiddlewareUtility.realTimeData.pointTime;

namespace MiddlewareUtility.realTimeData.pointValue
{
    public interface IPointValueFabric
    {
        IPointValue GetPointValue(DateTime time, double value);
        IPointValue GetPointValue(DateTime time, string value);
        IPointValue GetPointValue(DateTime time, int value);
        IPointValue GetPointValue(DateTime time, object value);
        IPointValue GetPointValue(IPointTimeStamp time, double value);
        IPointValue GetPointValue(IPointTimeStamp time, string value);
        IPointValue GetPointValue(IPointTimeStamp time, int value);
        IPointValue GetPointValue(IPointTimeStamp time, object value);
    }
}