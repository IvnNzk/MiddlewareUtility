namespace MiddlewareUtility.realTimeData.tagAbstraction.tagValue
{
    using System;


    public interface ITagValue<T>
    {
        string ErrorMessage { get; }
        bool IsGood { get; }
        T Value { get; }
        DateTime TimeStamp { get; }
        double ValueAsDouble { get; }
        int ValueAsInt { get; }
        string ValueAsString { get; }
    }
}