namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    public class PhysicalProperty : INumericPoint
    {
        protected EngUnit _engUnit;

        public PhysicalProperty(IPoint point, EngUnit engUnit, EnterprisePropertyType type, DateTime executionTime)
        {
            this._point = point;

            this._engUnit = engUnit;

            this.Type = type;

            this.ExecutionTime = executionTime;
        }

        public PhysicalProperty(IPoint point, EngUnit engUnit, EnterprisePropertyType type)
        {
            this._point = point;

            this._engUnit = engUnit;

            this.Type = type;

            this.ExecutionTime = DateTime.Now;
        }

        public string EngUnit
        {
            get
            {
                if (null != _engUnit)
                {
                    return _engUnit.Name;
                }
                else
                {
                    throw new EngUnitNotFoundException();
                }
            }
        }

        public DateTime ExecutionTime { get; set; }

        public string Name
        {
            get
            {
                if (_point != null)
                {
                    return _point.Name;
                }
                else
                {
                    return null;
                }
            }
        }

        public Type PointValueType
        {
            get
            {
                return _point.PointValueType;
            }
        }

        public EnterprisePropertyType Type { get; }

        public double Value
        {
            get
            {
                IPointValue value = RecordedValue(ExecutionTime, PointRetrievalMode.AtOrBefore);

                if (value.IsGood)
                {
                    return value.GetValueAsDouble();
                }
                else
                {
                    throw new BadPointValueException();
                }
            }
            set
            {
                IPointValue val = new PointValue(value, typeof(double), ExecutionTime);

                if (!WriteValue(val))
                {
                    throw new ValueNotWrittenException();
                }
            }
        }

        protected IPoint _point { get; }

        public IPointValue CurrentValue()
        {
            return RecordedValue(DateTime.Now, PointRetrievalMode.AtOrBefore);
        }

        public bool DeleteValues(DateTime timeStamp)
        {
            return _point.DeleteValues(timeStamp);
        }

        public bool DeleteValues()
        {
            return _point.DeleteValues();
        }

        public bool DeleteValues(DateTime timeStart, DateTime timeEnd)
        {
            return _point.DeleteValues(timeStart, timeEnd);
        }

        public bool DeleteValues(ITimeInterval timeInterval)
        {
            return _point.DeleteValues(timeInterval);
        }

        public IPointValue RecordedValue(DateTime timeStamp, PointRetrievalMode pointRetrievalMode)
        {
            return ConvertInputValue(_point.RecordedValue(timeStamp, pointRetrievalMode));
        }

        public List<IPointValue> RecordedValues(DateTime timeStart, DateTime timeEnd, PointBoundaryType pointBoundaryType)
        {
            return ConvertInputValues(_point.RecordedValues(timeStart, timeEnd, pointBoundaryType));
        }

        public List<IPointValue> RecordedValues(ITimeInterval timeInterval, PointBoundaryType pointBoundaryType)
        {
            return RecordedValues(timeInterval.DateTimeStart, timeInterval.DateTimeEnd, pointBoundaryType);
        }

        public bool WriteValue(IPointValue value)
        {
            return _point.WriteValue(ConvertOutputValue(value));
        }

        public bool WriteValues(List<IPointValue> values)

        {
            return _point.WriteValues(ConvertOutputValues(values));
        }

        protected virtual IPointValue ConvertInputValue(IPointValue value)
        {
            return new PointValue(_engUnit.InputConvert(value.GetValueAsDouble()), typeof(double), value.Timestamp);
        }

        protected virtual List<IPointValue> ConvertInputValues(List<IPointValue> values)
        {
            var result = new List<IPointValue>();
            foreach (var val in values)
            {
                result.Add(ConvertInputValue(val));
            }

            return result;
        }

        protected virtual IPointValue ConvertOutputValue(IPointValue value)
        {
            return new PointValue(_engUnit.OutputConvert(value.GetValueAsDouble()), typeof(double), value.Timestamp);
        }

        protected virtual List<IPointValue> ConvertOutputValues(List<IPointValue> values)
        {
            var result = new List<IPointValue>();
            foreach (var val in values)
            {
                result.Add(ConvertOutputValue(val));
            }

            return result;
        }
    }
}