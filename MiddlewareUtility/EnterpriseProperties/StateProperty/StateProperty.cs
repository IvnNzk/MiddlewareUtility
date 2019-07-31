namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    public class StateProperty : IStringPoint
    {
        protected List<string> _badStates;

        public StateProperty(IPoint point, EnterprisePropertyType type, DateTime executionTime, List<string> BadStates)
        {
            this._point = point;

            this.Type = type;

            this.ExecutionTime = executionTime;

            this._badStates = BadStates;
        }

        public StateProperty(IPoint point, EnterprisePropertyType type, List<string> BadStates)
        {
            this._point = point;

            this.Type = type;

            this.ExecutionTime = DateTime.Now;

            this._badStates = BadStates;
        }

        public string EngUnit
        {
            get
            {
                return _point.EngUnit;
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

        public string Value
        {
            get
            {
                IPointValue value = RecordedValue(ExecutionTime, PointRetrievalMode.AtOrBefore);

                if (value.IsGood)
                {
                    string result = value.GetValueAsString();
                    /*       if (IsBadState(result))
                           {
                               throw new BadStateException();
                           }*/
                    return result;
                }
                else
                {
                    throw new BadPointValueException();
                }
            }
            set
            {
                IPointValue val = new PointValue(value, typeof(string), ExecutionTime);

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

        public bool IsBadState()
        {
            return _badStates.Contains(Value);
        }

        public IPointValue RecordedValue(DateTime timeStamp, PointRetrievalMode pointRetrievalMode)
        {
            return _point.RecordedValue(timeStamp, pointRetrievalMode);
        }

        public List<IPointValue> RecordedValues(DateTime timeStart, DateTime timeEnd, PointBoundaryType pointBoundaryType)
        {
            return _point.RecordedValues(timeStart, timeEnd, pointBoundaryType);
        }

        public List<IPointValue> RecordedValues(ITimeInterval timeInterval, PointBoundaryType pointBoundaryType)
        {
            return RecordedValues(timeInterval.DateTimeStart, timeInterval.DateTimeEnd, pointBoundaryType);
        }

        public bool WriteValue(IPointValue value)
        {
            return _point.WriteValue(value);
        }

        public bool WriteValues(List<IPointValue> values)

        {
            return _point.WriteValues(values);
        }
    }
}