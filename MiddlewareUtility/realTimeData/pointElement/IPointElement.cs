namespace MiddlewareUtility.realTimeData.pointElement
{
    using System;
    using System.Collections.Generic;
    using MiddlewareUtility.intervals.timeInterval;
    using MiddlewareUtility.realTimeData.pointValue;

    public interface IPointElement
    {
        string Name { get; }
        string EngUnits { get; }
        IPointValue CurrentValue();
        IPointValue RecordedValue(DateTime timeStamp, PointRetrievalMode pointRetrievalMode);
        List<IPointValue> RecordedValues(DateTime timeStart, DateTime timeEnd, PointBoundaryType pointBoundaryType);
        List<IPointValue> RecordedValues(ITimeInterval timeInterval, PointBoundaryType pointBoundaryType);
    }
}