namespace MiddlewareUtility.Types
{
    using System;
    using System.Collections.Generic;

    public interface IPoint
    {
        string EngUnit { get; }

        string Name { get; }

        Type PointValueType { get; }

        IPointValue CurrentValue();

        bool DeleteValues(DateTime timeStamp);

        bool DeleteValues();

        bool DeleteValues(DateTime timeStart, DateTime timeEnd);

        bool DeleteValues(ITimeInterval timeInterval);

        IPointValue RecordedValue(DateTime timeStamp, PointRetrievalMode pointRetrievalMode);

        List<IPointValue> RecordedValues(DateTime timeStart, DateTime timeEnd, PointBoundaryType pointBoundaryType);

        List<IPointValue> RecordedValues(ITimeInterval timeInterval, PointBoundaryType pointBoundaryType);

        bool WriteValue(IPointValue value);

        bool WriteValues(List<IPointValue> values);
    }
}