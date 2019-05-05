using System;
using MiddlewareUtility.realTimeData.pointElement;
using MiddlewareUtility.realTimeData.tagAbstraction.tagValue;
using MiddlewareUtility.realTimeData.tagAbstraction.tagValue.implementation;

namespace MiddlewareUtility.realTimeData.tagAbstraction.tagElement.implementation
{
    public class TagElement : ITagElement
    {
        private readonly IPointElement _pointElement;

        public TagElement(IPointElement pointElement)
        {
            _pointElement = pointElement;
        }

        public string Name => _pointElement.Name;

        public string EngUnits => _pointElement.EngUnits;

        public ITagValue<object> CurrentValue =>
            throw new NotImplementedException(
                "logic failed in this moment.. see CurrentValue type in Tag and Point classes");

        public Type ValueType => throw new NotImplementedException();
    }
}