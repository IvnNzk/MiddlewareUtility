namespace MiddlewareUtility.Exceptions
{
    using System;

    /// <summary>
    /// Throws when wrapper can not write value in a point.
    /// </summary>
    [Serializable]
    public class ValueNotWrittenException : Exception
    {
        public ValueNotWrittenException() : base("Wrapper can not write value in a point")
        {
        }
    }
}