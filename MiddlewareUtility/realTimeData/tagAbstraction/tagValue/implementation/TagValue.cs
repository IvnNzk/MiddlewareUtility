using System;
using MiddlewareUtility.realTimeData.pointValue;

namespace MiddlewareUtility.realTimeData.tagAbstraction.tagValue.implementation
{
    public class TagValue<T> : ITagValue<T>
    {
        private readonly IPointValue _currentValue;

        public TagValue(IPointValue currentValue)
        {
            _currentValue = currentValue;
        }

        public string ErrorMessage => _currentValue.ErrorMessage;
        public bool IsGood => _currentValue.IsGood;
        public T Value => (T) _currentValue.Value;
        public DateTime TimeStamp => _currentValue.Timestamp;
        public double ValueAsDouble => (double) _currentValue.Value;
        public int ValueAsInt => (int) _currentValue.Value;
        public string ValueAsString => (string) _currentValue.Value;
    }
}