namespace MiddlewareUtility.Exceptions
{
    using System;

    /// <summary>
    /// Throws when PointValue`s value is incorrect
    /// </summary>
    [Serializable]
    public class BadPointValueException : Exception
    {
        public BadPointValueException() : base("PointValue`s value is incorrect")
        {
        }
    }
}