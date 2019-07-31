namespace MiddlewareUtility.Types
{
    using System;

    /// <summary>
    /// Reperesent interface for value retrieval from point
    /// </summary>
    public interface IPointValue
    {
        /// <summary>
        /// Return error message.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Checks if the value is valid
        /// </summary>
        bool IsGood { get; }

        /// <summary>
        /// Retrieval date and time of value or error
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        /// Return value as object.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Return type of value.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Checks if the value type equal to expected.
        /// </summary>
        /// <param name="type">Expected type of value</param>
        /// <returns></returns>
        bool CheckType(Type type);

        /// <summary>
        /// Return value as expected type. Before use check if the value is valid by method IsGood.
        /// Throw exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <typeparam name="T">Expected type of value</typeparam>
        /// <returns></returns>
        T GetValue<T>();

        /// <summary>
        /// Return value as double. Before use check if the value is valid by method IsGood. Throw
        /// exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <returns></returns>
        double GetValueAsDouble();

        /// <summary>
        /// Return value as string. Before use check if the value is valid by method IsGood. Throw
        /// exception (PointValueCastException) if input type not equal real type.
        /// </summary>
        /// <returns></returns>
        string GetValueAsString();
    }
}