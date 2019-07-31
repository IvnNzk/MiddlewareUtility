namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Types;
    using System;

    /// <summary>
    /// Reperesent value retrieval from point
    /// </summary>
    public class PointValue : IPointValue
    {
        private string _errorMessage;
        private DateTime _time;
        private Type _type;
        private object _value;

        /// <summary>
        /// Constructor for correct value from point.
        /// </summary>
        /// <param name="value">Value from point</param>
        /// <param name="type">Real value type</param>
        /// <param name="time">Retrieval date and time of value</param>
        public PointValue(object value, Type type, DateTime time)
        {
            Value = value;
            Timestamp = time;
            IsGood = true;
            _type = type;
        }

        /// <summary>
        /// Constructor for incorrect value from point. Use this constructor to return reason of
        /// incorrect state as error message.
        /// </summary>
        /// <param name="value">Value from point</param>
        /// <param name="type">Real value type</param>
        /// <param name="time">Retrieval date and time of incorrect value</param>
        /// <param name="errorMessage">Reason of incorrect state</param>
        public PointValue(object value, Type type, DateTime time, string errorMessage)
        {
            Value = value;
            Timestamp = time;
            IsGood = false;
            _type = type;
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// Constructor for incorrect value from point. Use this constructor to return reason of
        /// incorrect state as error message. Value is null.
        /// </summary>
        /// <param name="time">Retrieval date and time of error</param>
        /// <param name="errorMessage">Reason of incorrect state</param>

        public PointValue(DateTime time, string errorMessage)
        {
            Value = null;
            Timestamp = time;
            IsGood = false;
            _errorMessage = errorMessage;
            _type = typeof(object);
        }

        /// <summary>
        /// Return error message. Return empty string if value is correct.
        /// </summary>

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (IsGood)
                {
                    _errorMessage = string.Empty;
                }
                else
                {
                    _errorMessage = value;
                }
            }
        }

        /// <summary>
        /// Checks if the value is valid
        /// </summary>
        public bool IsGood { get; private set; }

        /// <summary>
        /// Retrieval date and time of value or error
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return _time;
            }
            private set
            {
                _time = value;
            }
        }

        /// <summary>
        /// Return value as object. Before use check if the value is valid by method IsGood. Anyway
        /// you get your value.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Return type of value. Before use check if the value is valid by method IsGood. If value
        /// is incorrect return type of Object.
        /// </summary>
        public Type ValueType
        {
            get => _type;
        }

        /// <summary>
        /// Checks if the value type equal to expected.
        /// </summary>
        /// <param name="type">Expected type of value</param>
        /// <returns></returns>
        public bool CheckType(Type type)
        {
            return this.ValueType == type;
        }

        /// <summary>
        /// Return value as expected type. Before use check if the value is valid by method IsGood.
        /// Throw exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <typeparam name="T">Expected type of value</typeparam>
        /// <returns>Value</returns>
        public T GetValue<T>()
        {
            if (CheckType(typeof(T)))
            {
                return (T)_value;
            }
            else
            {
                throw new PointValueCastException();
            }
        }

        /// <summary>
        /// Return value as double. Before use check if the value is valid by method IsGood. Throw
        /// exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <returns></returns>
        public double GetValueAsDouble()
        {
            return GetValue<double>();
        }

        /// <summary>
        /// Return value as string. Before use check if the value is valid by method IsGood. Throw
        /// exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <returns></returns>
        public string GetValueAsString()
        {
            return GetValue<string>();
        }
    }
}