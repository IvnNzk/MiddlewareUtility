namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class PointValueTypeException : Exception
    {
        public PointValueTypeException() : base("Не корректный тип точки")
        {
        }
    }
}