namespace MiddlewareUtility.Exceptions
{
    using System;

    /// <summary>
    /// Throws when PointValue`s value can not be casted to expected type.
    /// </summary>
    [Serializable]
    public class PointValueCastException : Exception
    {
        public PointValueCastException() : base("PointValue`s value can not be casted to expected type")
        {
        }
    }
}