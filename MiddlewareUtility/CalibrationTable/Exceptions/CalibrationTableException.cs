namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class CalibrationTableException : Exception
    {
        public CalibrationTableException() : base("Can not get values from calibration table")
        {
        }

        public CalibrationTableException(string Message) : base(Message)
        {
        }
    }
}