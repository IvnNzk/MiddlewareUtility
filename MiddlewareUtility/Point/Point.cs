namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represent the point that contains timevalued values.
    /// </summary>
    public class Point : IPoint
    {
        private static readonly string BaseExceptionMessage = "Method should be implemented in child class";

        /// <summary>
        /// Constructor for point. Сan only be created in a descendant class.
        /// </summary>
        /// <param name="pointValueType"></param>
        /// <param name="engUnit"></param>
        /// <param name="name"></param>
        protected Point(Type pointValueType, string engUnit, string name)
        {
            this.EngUnit = engUnit;
            this.Name = name;
            this.PointValueType = pointValueType;
        }

        public string EngUnit { get; protected set; }
        public string Name { get; protected set; }

        public virtual Type PointValueType { get; protected set; }

        public virtual IPointValue CurrentValue()
        {
            return RecordedValue(DateTime.Now, PointRetrievalMode.AtOrBefore);
        }

        public virtual bool DeleteValues(DateTime timeStamp)
        {
            throw new NotSupportedException(BaseExceptionMessage);
        }

        public virtual bool DeleteValues()
        {
            return DeleteValues(DateTime.Now);
        }

        public virtual bool DeleteValues(DateTime timeStart, DateTime timeEnd)
        {
            throw new NotSupportedException(BaseExceptionMessage);
        }

        public virtual bool DeleteValues(ITimeInterval timeInterval)
        {
            return DeleteValues(timeInterval.DateTimeStart, timeInterval.DateTimeEnd);
        }

        public virtual IPointValue RecordedValue(DateTime timeStamp, PointRetrievalMode pointRetrievalMode)
        {
            throw new NotSupportedException(BaseExceptionMessage);
        }

        public virtual List<IPointValue> RecordedValues(DateTime timeStart, DateTime timeEnd, PointBoundaryType pointBoundaryType)
        {
            throw new NotSupportedException(BaseExceptionMessage);
        }

        public virtual List<IPointValue> RecordedValues(ITimeInterval timeInterval, PointBoundaryType pointBoundaryType)
        {
            return RecordedValues(timeInterval.DateTimeStart, timeInterval.DateTimeEnd, pointBoundaryType);
        }

        public virtual bool WriteValue(IPointValue value)
        {
            throw new NotSupportedException(BaseExceptionMessage);
        }

        public virtual bool WriteValues(List<IPointValue> values)
        {
            bool result = true;

            foreach (var value in values)
            {
                result = result && WriteValue(value);
            }

            return result;
        }
    }
}