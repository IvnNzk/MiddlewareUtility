using System;
using MiddlewareUtility.realTimeData.tagAbstraction.tagValue;

namespace MiddlewareUtility.realTimeData.tagAbstraction.tagElement
{
    public interface ITagElement
    {
        string Name { get; }

        string EngUnits { get; }

        ITagValue<object> CurrentValue { get; }

        Type ValueType { get; }
    }
}