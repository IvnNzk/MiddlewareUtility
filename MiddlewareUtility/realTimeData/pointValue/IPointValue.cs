namespace MiddlewareUtility.realTimeData.pointValue
{
    using System;

    public interface IPointValue
    {
        object Value { get; }
        DateTime Timestamp { get; }
        bool IsGood { get; }
        Type ValueType { get; }

        string ErrorMessage { get; }
    }
}